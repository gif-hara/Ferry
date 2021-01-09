using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// <see cref="Skill"/>を生成するクラス
    /// </summary>
    public static class SkillFactory
    {
        public static ISkill Create(SkillType skillType, int level)
        {
            switch (skillType)
            {
                case SkillType.AbnormalStateGiveDamageMySelf_Poison:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Poison, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_Paralysis:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Paralysis, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_Confusion:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Confusion, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_BlindEyes:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.BlindEyes, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_Flinch:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Flinch, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_Vitals:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Vitals, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_Quilting:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Quilting, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_Tiredness:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Tiredness, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_Seal:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Seal, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_Healing:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Healing, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_MindEyes:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.MindEyes, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_Absorption:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Absorption, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_FastRunner:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.FastRunner, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageMySelf_CounterAttack:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.CounterAttack, TargetType.Myself);
                case SkillType.AbnormalStateGiveDamageOpponent_Poison:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Poison, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_Paralysis:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Paralysis, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_Confusion:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Confusion, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_BlindEyes:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.BlindEyes, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_Flinch:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Flinch, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_Vitals:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Vitals, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_Quilting:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Quilting, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_Tiredness:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Tiredness, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_Seal:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Seal, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_Healing:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Healing, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_MindEyes:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.MindEyes, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_Absorption:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.Absorption, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_FastRunner:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.FastRunner, TargetType.Opponent);
                case SkillType.AbnormalStateGiveDamageOpponent_CounterAttack:
                    return new AbnormalStateGiveDamage(level, AbnormalStateType.CounterAttack, TargetType.Opponent);
                case SkillType.AbnormalStateDisable_Poison:
                    return new AbnormalStateDisable(level, AbnormalStateType.Poison);
                case SkillType.AbnormalStateDisable_Paralysis:
                    return new AbnormalStateDisable(level, AbnormalStateType.Paralysis);
                case SkillType.AbnormalStateDisable_Confusion:
                    return new AbnormalStateDisable(level, AbnormalStateType.Confusion);
                case SkillType.AbnormalStateDisable_BlindEyes:
                    return new AbnormalStateDisable(level, AbnormalStateType.BlindEyes);
                case SkillType.AbnormalStateDisable_Flinch:
                    return new AbnormalStateDisable(level, AbnormalStateType.Flinch);
                case SkillType.AbnormalStateDisable_Vitals:
                    return new AbnormalStateDisable(level, AbnormalStateType.Vitals);
                case SkillType.AbnormalStateDisable_Quilting:
                    return new AbnormalStateDisable(level, AbnormalStateType.Quilting);
                case SkillType.AbnormalStateDisable_Tiredness:
                    return new AbnormalStateDisable(level, AbnormalStateType.Tiredness);
                case SkillType.AbnormalStateDisable_Seal:
                    return new AbnormalStateDisable(level, AbnormalStateType.Seal);
                case SkillType.AbnormalStateDisable_Healing:
                    return new AbnormalStateDisable(level, AbnormalStateType.Healing);
                case SkillType.AbnormalStateDisable_MindEyes:
                    return new AbnormalStateDisable(level, AbnormalStateType.MindEyes);
                case SkillType.AbnormalStateDisable_Absorption:
                    return new AbnormalStateDisable(level, AbnormalStateType.Absorption);
                case SkillType.AbnormalStateDisable_FastRunner:
                    return new AbnormalStateDisable(level, AbnormalStateType.FastRunner);
                case SkillType.AbnormalStateDisable_CounterAttack:
                    return new AbnormalStateDisable(level, AbnormalStateType.CounterAttack);
                default:
                    Assert.IsTrue(false, $"{skillType}は未対応です");
                    return null;
            }
        }
    }
}
