using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.AI
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class Sub : IOwner
    {
        [SerializeField]
        private string name = default;
        public string Name => name;

        [SerializeReference, SubclassSelector]
        private ICommandSelector commandSelector = default;
        public ICommandSelector CommandSelector => CommandSelector;

        public int ElapsedTurn => owner.ElapsedTurn - activateTurn;

        [SerializeField]
        private List<ChangeAI> changeAIs = default;

        private IOwner owner;

        private int activateTurn;

        /// <summary>
        /// このAIがアクティブになった際の処理
        /// </summary>
        public void Activate(IOwner owner)
        {
            this.owner = owner;
            activateTurn = owner.ElapsedTurn;
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
