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
                case SkillType.AbnormalStateAllTheWay_Poison:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Poison);
                case SkillType.AbnormalStateAllTheWay_Paralysis:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Paralysis);
                case SkillType.AbnormalStateAllTheWay_Confusion:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Confusion);
                case SkillType.AbnormalStateAllTheWay_BlindEyes:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.BlindEyes);
                case SkillType.AbnormalStateAllTheWay_Flinch:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Flinch);
                case SkillType.AbnormalStateAllTheWay_Vitals:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Vitals);
                case SkillType.AbnormalStateAllTheWay_Quilting:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Quilting);
                case SkillType.AbnormalStateAllTheWay_Tiredness:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Tiredness);
                case SkillType.AbnormalStateAllTheWay_Seal:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Seal);
                case SkillType.AbnormalStateAllTheWay_Healing:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Healing);
                case SkillType.AbnormalStateAllTheWay_MindEyes:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.MindEyes);
                case SkillType.AbnormalStateAllTheWay_Absorption:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.Absorption);
                case SkillType.AbnormalStateAllTheWay_FastRunner:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.FastRunner);
                case SkillType.AbnormalStateAllTheWay_CounterAttack:
                    return new AbnormalStateAllTheWay(level, AbnormalStateType.CounterAttack);
                case SkillType.AbnormalStateBattleStart_Poison:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Poison);
                case SkillType.AbnormalStateBattleStart_Paralysis:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Paralysis);
                case SkillType.AbnormalStateBattleStart_Confusion:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Confusion);
                case SkillType.AbnormalStateBattleStart_BlindEyes:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.BlindEyes);
                case SkillType.AbnormalStateBattleStart_Flinch:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Flinch);
                case SkillType.AbnormalStateBattleStart_Vitals:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Vitals);
                case SkillType.AbnormalStateBattleStart_Quilting:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Quilting);
                case SkillType.AbnormalStateBattleStart_Tiredness:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Tiredness);
                case SkillType.AbnormalStateBattleStart_Seal:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Seal);
                case SkillType.AbnormalStateBattleStart_Healing:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Healing);
                case SkillType.AbnormalStateBattleStart_MindEyes:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.MindEyes);
                case SkillType.AbnormalStateBattleStart_Absorption:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.Absorption);
                case SkillType.AbnormalStateBattleStart_FastRunner:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.FastRunner);
                case SkillType.AbnormalStateBattleStart_CounterAttack:
                    return new AbnormalStateBattleStart(level, AbnormalStateType.CounterAttack);
                case SkillType.AbnormalStateTakeDamageMySelf_Poison:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Poison, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_Paralysis:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Paralysis, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_Confusion:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Confusion, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_BlindEyes:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.BlindEyes, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_Flinch:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Flinch, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_Vitals:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Vitals, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_Quilting:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Quilting, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_Tiredness:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Tiredness, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_Seal:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Seal, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_Healing:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Healing, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_MindEyes:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.MindEyes, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_Absorption:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Absorption, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_FastRunner:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.FastRunner, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageMySelf_CounterAttack:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.CounterAttack, TargetType.Myself);
                case SkillType.AbnormalStateTakeDamageOpponent_Poison:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Poison, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_Paralysis:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Paralysis, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_Confusion:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Confusion, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_BlindEyes:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.BlindEyes, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_Flinch:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Flinch, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_Vitals:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Vitals, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_Quilting:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Quilting, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_Tiredness:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Tiredness, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_Seal:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Seal, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_Healing:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Healing, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_MindEyes:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.MindEyes, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_Absorption:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.Absorption, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_FastRunner:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.FastRunner, TargetType.Opponent);
                case SkillType.AbnormalStateTakeDamageOpponent_CounterAttack:
                    return new AbnormalStateTakeDamage(level, AbnormalStateType.CounterAttack, TargetType.Opponent);
                case SkillType.AttackAttributeResistance_Slash:
                    return new AttackAttributeResistance(level, AttackAttribute.Slash);
                case SkillType.AttackAttributeResistance_Spear:
                    return new AttackAttributeResistance(level, AttackAttribute.Spear);
                case SkillType.AttackAttributeResistance_Blow:
                    return new AttackAttributeResistance(level, AttackAttribute.Blow);
                case SkillType.AttackAttributeResistance_Magic:
                    return new AttackAttributeResistance(level, AttackAttribute.Magic);
                case SkillType.AttackAttributeDisable_Slash:
                    return new AttackAttributeDisable(level, AttackAttribute.Slash);
                case SkillType.AttackAttributeDisable_Spear:
                    return new AttackAttributeDisable(level, AttackAttribute.Spear);
                case SkillType.AttackAttributeDisable_Blow:
                    return new AttackAttributeDisable(level, AttackAttribute.Blow);
                case SkillType.AttackAttributeDisable_Magic:
                    return new AttackAttributeDisable(level, AttackAttribute.Magic);
                case SkillType.StatusUp_HitPoint:
                    return new StatusUp(level, StatusType.HitPoint);
                case SkillType.StatusUp_Attack:
                    return new StatusUp(level, StatusType.Attack);
                case SkillType.StatusUp_Defense:
                    return new StatusUp(level, StatusType.Defense);
                case SkillType.StatusUp_Evasion:
                    return new StatusUp(level, StatusType.Evasion);
                case SkillType.StatusUp_Critical:
                    return new StatusUp(level, StatusType.Critical);
                default:
                    Assert.IsTrue(false, $"{skillType}は未対応です");
                    return null;
            }
        }
    }
}
