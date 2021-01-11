using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public static class BattleUtility
    {
        /// <summary>
        /// <paramref name="targetType"/>から対象となる<see cref="BattleCharacter"/>を返す
        /// </summary>
        /// <remarks>
        /// 基本的に<paramref name="attacker"/>は自分自身が入ります
        /// </remarks>
        public static BattleCharacter GetBattleCharacter(BattleCharacter attacker, BattleCharacter target, TargetType targetType)
        {
            return targetType == TargetType.Myself ? attacker : target;
        }
    }
}
