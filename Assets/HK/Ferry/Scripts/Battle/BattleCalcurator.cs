using System.Linq;
using HK.Ferry.BattleSystems.Skills;
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
        public static DamageResult GetDamage(
            BattleCharacter attacker,
            BattleCharacter target,
            AttackAttribute attackerSideAttackAttribute,
            float rate,
            bool calcurateCritical
            )
        {
            var result = new DamageResult();
            try
            {
                checked
                {
                    // 無効化された場合は0を返す
                    // TODO: 無効化した旨を返せるようにしたほうがいいかも
                    foreach (var s in target.Skills.OfType<BattleEvent.IGetDamageDisableFromAttackAttribute>())
                    {
                        if (s.IsDisable(attackerSideAttackAttribute))
                        {
                            result.damage = 0;
                            return result;
                        }
                    }

                    var x = attacker.CurrentSpec.Status.attack.Value;
                    var a = target.CurrentSpec.Status.defense.Value;

                    var damage = x * (x - (a / 1.0f)) / 100.0f;
                    damage = damage < 0 ? 0 : damage;

                    // ダメージを受ける側が軽減率を所持している場合は適用する
                    foreach (var s in target.Skills.OfType<BattleEvent.IGetDamageReductionRateFromAttackAttribute>())
                    {
                        rate -= s.GetReductionRate(attackerSideAttackAttribute);
                    }

                    if (calcurateCritical)
                    {
                        var random = Random.value;
                        var critical = attacker.CurrentSpec.Status.critical.Value / 100.0f;
                        if (critical > random)
                        {
                            damage *= GetCriticalRate(attacker);
                            result.isCritical = true;
                        }
                    }

                    result.damage = Mathf.FloorToInt(damage * rate);

                    return result;
                }
            }
            catch
            {
                result.damage = 99999;
                return result;
            }
        }

        /// <summary>
        /// 毒によるダメージ量を返す
        /// </summary>
        public static int GetDamageFromPoison(BattleCharacter target)
        {
            return target.CurrentSpec.Status.hitPoint.Value / 10;
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

        /// <summary>
        /// ステータス上昇系スキルの上昇量を返す
        /// </summary>
        public static int GetStatusUpAddValue(StatusType statusType, int level)
        {
            switch (statusType)
            {
                case StatusType.HitPoint:
                    return 100 * level;
                case StatusType.Attack:
                    return 20 * level;
                case StatusType.Defense:
                    return 20 * level;
                case StatusType.Evasion:
                    return 10 * level;
                case StatusType.Critical:
                    return 10 * level;
                default:
                    Assert.IsTrue(false, $"{statusType}は未対応です");
                    return 0;
            }
        }

        public static int GetStatusUpGiveDamageAddValue(StatusType statusType, int level)
        {
            switch (statusType)
            {
                case StatusType.HitPoint:
                    return 20 * level + 30;
                case StatusType.Attack:
                    return 2 * level + 3;
                case StatusType.Defense:
                    return 2 * level + 3;
                case StatusType.Evasion:
                    return 1 * level;
                case StatusType.Critical:
                    return 1 * level;
                default:
                    Assert.IsTrue(false, $"{statusType}は未対応です");
                    return 0;
            }
        }

        public static int GetStatusUpTakeDamageAddValue(StatusType statusType, int level)
        {
            switch (statusType)
            {
                case StatusType.HitPoint:
                    return 20 * level + 30;
                case StatusType.Attack:
                    return 2 * level + 3;
                case StatusType.Defense:
                    return 2 * level + 3;
                case StatusType.Evasion:
                    return 1 * level;
                case StatusType.Critical:
                    return 1 * level;
                default:
                    Assert.IsTrue(false, $"{statusType}は未対応です");
                    return 0;
            }
        }

        public static float GetBarrageDamageRate(int level)
        {
            return 0.05f * level + 0.05f;
        }

        /// <summary>
        /// スキルによる状態異常の耐性値を返す
        /// </summary>
        public static float GetAbnormalStateResistanceFromSkill(int level)
        {
            var resistances = new float[] { 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };
            var index = Mathf.Clamp(level - 1, 0, resistances.Length - 1);

            return resistances[index];
        }

        /// <summary>
        /// 与ダメ、被ダメ時に状態異常を付与する確率を返す
        /// </summary>
        public static float GetAbnormalStateAddRate(AbnormalStateType abnormalStateType, int level)
        {
            float[] resistances;
            switch (abnormalStateType)
            {
                case AbnormalStateType.Poison:
                    resistances = new float[] { 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };
                    break;
                case AbnormalStateType.Paralysis:
                    resistances = new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
                    break;
                case AbnormalStateType.Confusion:
                    resistances = new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
                    break;
                case AbnormalStateType.BlindEyes:
                    resistances = new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
                    break;
                case AbnormalStateType.Flinch:
                    resistances = new float[] { 0.1f, 0.15f, 0.2f, 0.25f, 0.3f };
                    break;
                case AbnormalStateType.Vitals:
                    resistances = new float[] { 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };
                    break;
                case AbnormalStateType.Quilting:
                    resistances = new float[] { 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };
                    break;
                case AbnormalStateType.Tiredness:
                    resistances = new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
                    break;
                case AbnormalStateType.Seal:
                    resistances = new float[] { 0.1f, 0.15f, 0.2f, 0.25f, 0.3f };
                    break;
                case AbnormalStateType.Healing:
                    resistances = new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
                    break;
                case AbnormalStateType.MindEyes:
                    resistances = new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
                    break;
                case AbnormalStateType.Absorption:
                    resistances = new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
                    break;
                case AbnormalStateType.FastRunner:
                    resistances = new float[] { 0.1f, 0.15f, 0.2f, 0.25f, 0.3f };
                    break;
                case AbnormalStateType.CounterAttack:
                    resistances = new float[] { 0.2f, 0.4f, 0.6f, 0.8f, 1.0f };
                    break;
                default:
                    Assert.IsTrue(false, $"{abnormalStateType}は未対応です");
                    resistances = new float[0];
                    break;
            }

            var index = Mathf.Clamp(level - 1, 0, resistances.Length - 1);
            return resistances[index];
        }

        public static int GetStatusUpOnDebuffAddValue(BattleCharacter owner, StatusType statusType, int level)
        {
            var value = owner.BaseSpec.Status.Get(statusType).Value;
            return Mathf.FloorToInt(value * level * 0.1f);
        }

        public static float GetCriticalRate(BattleCharacter battleCharacter)
        {
            var rates = new float[] { 1.5f, 1.6f, 1.75f, 2.0f };
            var level = Mathf.Clamp(battleCharacter.GetSkillLevel(SkillType.SuperCritical), 0, rates.Length - 1);

            return rates[level];
        }

        public static float GetMotionLessAddRate(int level)
        {
            var rates = new float[] { 1.05f, 1.1f, 1.2f };
            var index = Mathf.Clamp(level - 1, 0, rates.Length - 1);

            return rates[index];
        }

        public static float GetFightingAddRate(int level)
        {
            var rates = new float[] { 1.05f, 1.1f, 1.2f };
            var index = Mathf.Clamp(level - 1, 0, rates.Length - 1);

            return rates[index];
        }

        public static float GetSamuraiTechniqueAddRate(int level)
        {
            var rates = new float[] { 1.05f, 1.1f, 1.2f };
            var index = Mathf.Clamp(level - 1, 0, rates.Length - 1);

            return rates[index];
        }

        public static float GetShinobiTechniqueAddRate(int level)
        {
            var rates = new float[] { 1.05f, 1.1f, 1.2f };
            var index = Mathf.Clamp(level - 1, 0, rates.Length - 1);

            return rates[index];
        }
    }
}
