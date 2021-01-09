using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public static class BattleEvent
    {
        /// <summary>
        /// ダメージを与えた際のイベントを持つインターフェイス
        /// </summary>
        public interface IOnGiveDamage
        {
            void OnGiveDamage(BattleCharacter attacker, BattleCharacter target);
        }
    }
}
