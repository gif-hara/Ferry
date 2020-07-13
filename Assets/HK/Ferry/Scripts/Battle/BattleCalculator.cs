using HK.Ferry.ActorControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// バトル関連の計算式をまとめるクラス
    /// </summary>
    public static class BattleCalculator
    {
        /// <summary>
        /// ダメージ量を計算する
        /// </summary>
        public static int GetDamage(Actor attacker, Actor receiver)
        {
            return attacker.Status.Attack.Get - receiver.Status.Defense.Get;
        }
    }
}
