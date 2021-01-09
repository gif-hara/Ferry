using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// 攻撃属性のダメージ量を減少させる<see cref="ISkill"/>
    /// </summary>
    public sealed class AttackAttributeResistance : Skill, IGetDamageReductionRateFromAttackAttribute
    {
        private AttackAttribute attackAttribute;

        public AttackAttributeResistance(int level, AttackAttribute attackAttribute) : base(level)
        {
            this.attackAttribute = attackAttribute;
        }

        public float GetReductionRate(AttackAttribute attackattackerSideAttackAttribute)
        {
            return BattleCalcurator.GetAttackAttributeReductionRate(attackattackerSideAttackAttribute, attackAttribute, Level);
        }
    }
}
