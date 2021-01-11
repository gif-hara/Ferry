using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// <see cref="Constants.SkillType"/>のみ保持してる<see cref="ISkill"/>
    /// </summary>
    public sealed class SkillTypeHolder : Skill
    {
        public readonly SkillType SkillType;

        public SkillTypeHolder(int level, SkillType skillType) : base(level)
        {
            this.SkillType = skillType;
        }
    }
}
