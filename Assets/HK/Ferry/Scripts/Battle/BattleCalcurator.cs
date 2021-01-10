using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// バトルに関する計算式をまとめるクラス
    /// </summary>
    public static class BattleCalcurator
    {
        public static int GetDamage(BattleCharacter attacker, BattleCharacter target)
        {
            try
            {
                checked
                {
                    // 無効化された場合は0を返す
                    // TODO: 無効化した旨を返せるようにしたほうがいいかも
                    foreach (var s in target.Skills.OfType<BattleEvent.IGetDamageDisableFromAttackAttribute>())
                    {
                        if (s.IsDisable(attacker.CurrentSpec.AttackAttribute))
                        {
                            return 0;
                        }
                    }

                    var x = attacker.CurrentSpec.Status.attack.Value;
                    var a = target.CurrentSpec.Status.defense.Value;

                    var damage = x * (x - (a / 3.0f)) / 100.0f;
                    damage = damage < 0 ? 0 : damage;
                    var rate = 1.0f;

                    // ダメージを受ける側が軽減率を所持している場合は適用する
                    foreach (var s in target.Skills.OfType<BattleEvent.IGetDamageReductionRateFromAttackAttribute>())
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

        /// <summary>
        /// 攻撃属性によるダメージ無効したか返す
        /// </summary>
        public static bool IsAttackAttributeDisable(AttackAttribute attacker, AttackAttribute defense, int level)
        {
            if (attacker == defense)
            {
                var random = Random.value;
                var value = Mathf.Clamp01(0.1f * level);
                return value > random;
            }

            return false;
        }
    }
}
