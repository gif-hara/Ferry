using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// ステータスを上昇させる<see cref="ISkill"/>
    /// </summary>
    public sealed class StatusUp : Skill, IStatusUp
    {
        private readonly StatusType statusType;

        public StatusUp(int level, StatusType statusType) : base(level)
        {
            this.statusType = statusType;
        }

        StatusType IStatusUp.StatusType => statusType;

        public int GetAddValue()
        {
            return BattleCalcurator.GetStatusUpAddValue(statusType, Level);
        }
    }
}
