using System.Collections.Generic;
using System.Linq;
using HK.Ferry.Database;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.AI
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/AI")]
    public sealed class AIScriptableObject : ScriptableObject, IAI, IOwner
    {
        [SerializeField]
        private List<Sub> subs = default;

        [SerializeField]
        private List<ChangeAI> changeAIs = default;

        private Sub currentSub = null;

        public int ElapsedTurn { get; private set; }

        public MasterDataCommand.Record GetCommand()
        {
            // 現在のSubが無い場合は一番最初のSubに割り当てる
            if (currentSub == null)
            {
                currentSub = subs[0];
            }

            ++ElapsedTurn;
            var thinkingCount = 0;

            // 先にchangeAIsの条件を満たしていた場合はcurrentSubを切り替える
            var nextAIName = GetChangeAIName();
            if (string.IsNullOrEmpty(nextAIName))
            {
                currentSub = GetSub(nextAIName);
            }

            // Sub側の思考を開始する
            nextAIName = currentSub.GetChangeAIName();
            while (!string.IsNullOrEmpty(nextAIName))
            {
                // 無限ループ防止
                if (thinkingCount > 100)
                {
                    Assert.IsTrue(false, "思考回数の限度値を超えました");
                    break;
                }
                ++thinkingCount;

                currentSub = GetSub(nextAIName);

                currentSub.Activate(this);
                nextAIName = currentSub.GetChangeAIName();
            }

            return currentSub.CommandSelector.Get();
        }

        private Sub GetSub(string name)
        {
            var result = subs.FirstOrDefault(x => x.Name == name);
            Assert.IsNotNull(currentSub, $"\"{name}\"というAIが存在しません");

            return result;
        }

        /// <summary>
        /// 次に切り替えるAIの名前を返す
        /// 切り替える必要がない場合は<see cref="string.Empty"/>を返す
        /// </summary>
        public string GetChangeAIName()
        {
            foreach (var x in changeAIs)
            {
                if (x.Condition.IsSatisfy(this))
                {
                    return x.NextAI;
                }
            }

            return string.Empty;
        }
    }
}
