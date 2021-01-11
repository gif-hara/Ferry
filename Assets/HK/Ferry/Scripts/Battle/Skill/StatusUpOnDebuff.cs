using System;
using UniRx;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// デバフが付与された際にステータスを加算する<see cref="ISkill"/>
    /// </summary>
    public sealed class StatusUpOnDebuff : Skill, IModifiedAbnormalState
    {
        private readonly StatusType statusType;

        public StatusUpOnDebuff(int level, StatusType statusType) : base(level)
        {
            this.statusType = statusType;
        }

        public void OnAddedAbnormalState(AbnormalStateType abnormalStateType, BattleCharacter owner)
        {
            var value = BattleCalcurator.GetStatusUpOnDebuffAddValue(owner, statusType, Level);
            owner.CurrentSpec.Status.Add(statusType, value);
        }

        public void OnRemovedAbnormalState(AbnormalStateType abnormalStateType, BattleCharacter owner)
        {
            var value = BattleCalcurator.GetStatusUpOnDebuffAddValue(owner, statusType, Level);
            owner.CurrentSpec.Status.Add(statusType, -value);
        }
    }
}
