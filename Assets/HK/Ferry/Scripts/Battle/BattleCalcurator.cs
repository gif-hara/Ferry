using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public static class BattleCalcurator
    {
        public static int GetDamage(BattleCharacter attacker, BattleCharacter defenser)
        {
            try
            {
                checked
                {
                    var x = attacker.CurrentSpec.Status.attack.Value;
                    var a = defenser.CurrentSpec.Status.defense.Value;

                    var damage = x * (x - (a / 3.0f)) / 100.0f;
                    damage = damage < 0 ? 0 : damage;
                    var rate = 1.0f;

                    foreach (var s in defenser.Skills.OfType<BattleEvent.IGetDamageReductionRateFromAttackAttribute>())
                    {
                        rate -= s.GetReductionRate(attacker.CurrentSpec.AttackAttribute);
                    }

                    return Mathf.FloorToInt(damage * rate);
                }
            }
            catch
            {
                return 99999;
            }
        }

        /// <summary>
        /// 攻撃属性によるダメージ軽減率を返す
        /// </summary>
        public static float GetAttackAttributeReductionRate(AttackAttribute attacker, AttackAttribute defense, int level)
        {
            if (attacker == defense)
            {
                return Mathf.Clamp01(0.1f * level);
            }

            return 0.0f;
        }
    }
}
