using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// ダメージを与えた際に状態異常を付与する<see cref="ISkill"/>
    /// </summary>
    public sealed class AbnormalStateGiveDamage : Skill, IOnGiveDamage
    {
        private AbnormalStateType abnormalStateType;

        private TargetType targetType;

        public AbnormalStateGiveDamage(int level, AbnormalStateType abnormalStateType, TargetType targetType) : base(level)
        {
            this.abnormalStateType = abnormalStateType;
            this.targetType = targetType;
        }

        public void OnGiveDamage(BattleCharacter attacker, BattleCharacter target)
        {
            throw new System.NotImplementedException();
        }
    }
}
