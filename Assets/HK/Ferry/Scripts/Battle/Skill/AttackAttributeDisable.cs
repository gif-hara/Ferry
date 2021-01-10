using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// 攻撃属性のダメージを無効化する<see cref="ISkill"/>
    /// </summary>
    public sealed class AttackAttributeDisable : Skill, IGetDamageDisableFromAttackAttribute
    {
        private AttackAttribute attackAttribute;

        public AttackAttributeDisable(int level, AttackAttribute attackAttribute) : base(level)
        {
            this.attackAttribute = attackAttribute;
        }

        public bool IsDisable(AttackAttribute attackerSideAttackAttribute)
        {
            return BattleCalcurator.IsAttackAttributeDisable(attackerSideAttackAttribute, attackAttribute, Level);
        }
    }
}
