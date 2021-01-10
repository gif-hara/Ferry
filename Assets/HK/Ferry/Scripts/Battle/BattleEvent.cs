using System;
using UniRx;
using static HK.Ferry.Constants;

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
            IObservable<Unit> OnGiveDamage(BattleSystem battleSystem, BattleCharacter attacker, BattleCharacter target);
        }

        /// <summary>
        /// ダメージを受けた際のイベントを持つインターフェイス
        /// </summary>
        public interface IOnTakeDamage
        {
            IObservable<Unit> OnTakeDamage(BattleSystem battleSystem, BattleCharacter attacker, BattleCharacter target);
        }

        /// <summary>
        /// バトルが開始した際のイベントを持つインターフェイス
        /// </summary>
        public interface IOnStartBattle
        {
            IObservable<Unit> OnStartBattle();
        }

        /// <summary>
        /// <see cref="AttackAttribute"/>からダメージ軽減率を返すインターフェイス
        /// </summary>
        public interface IGetDamageReductionRateFromAttackAttribute
        {
            /// <summary>
            /// ダメージ軽減率を返す
            /// <c>0</c>ならダメージも<c>0</c>になる
            /// </summary>
            float GetReductionRate(AttackAttribute attackerSideAttackAttribute);
        }

        /// <summary>
        /// <see cref="AttackAttribute"/>からダメージを無効化するインターフェイス
        /// </summary>
        public interface IGetDamageDisableFromAttackAttribute
        {
            /// <summary>
            /// ダメージを無効化するか返す
            /// </summary>
            bool IsDisable(AttackAttribute attackerSideAttackAttribute);
        }

        /// <summary>
        /// ステータスを上昇させるインターフェイス
        /// </summary>
        public interface IStatusUp
        {
            /// <summary>
            /// 加算される値を返す
            /// </summary>
            int GetAddValue();

            StatusType StatusType { get; }
        }
    }
}
