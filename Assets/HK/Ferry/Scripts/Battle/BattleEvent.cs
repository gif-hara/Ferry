using System;
using UniRx;

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
            IObservable<Unit> OnGiveDamage(BattleCharacter attacker, BattleCharacter target);
        }

        /// <summary>
        /// バトルが開始した際のイベントを持つインターフェイス
        /// </summary>
        public interface IOnStartBattle
        {
            IObservable<Unit> OnStartBattle();
        }
    }
}
