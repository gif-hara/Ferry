using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Skill : ISkill
    {
        public int Level
        {
            get;
        }

        public Skill(int level)
        {
            Level = level;
        }
    }
}
