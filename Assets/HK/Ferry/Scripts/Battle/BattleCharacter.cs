using System.Collections.Generic;
using System.Linq;
using HK.Ferry.BattleSystems.Skills;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BattleCharacter
    {
        public CharacterSpec CurrentSpec
        {
            get;
            private set;
        }

        public CharacterSpec BaseSpec
        {
            get;
            private set;
        }

        public List<ISkill> Skills
        {
            get;
            private set;
        }

        public BattleCharacter(CharacterSpec characterSpec)
        {
            CurrentSpec = new CharacterSpec(characterSpec);
            BaseSpec = characterSpec;
            Skills = CurrentSpec.SkillTypes
                .GroupBy(x => x)
                .Select(x => SkillFactory.Create(x.Key, x.Count()))
                .ToList();
        }

        public float HitPointRate => (float)CurrentSpec.Status.hitPoint.Value / BaseSpec.Status.hitPoint.Value;

        public virtual void StartTurn()
        {
        }

        public void TakeDamage(int value)
        {
            CurrentSpec.Status.hitPoint.Value -= value;
        }

        public bool IsDead => CurrentSpec.Status.hitPoint.Value <= 0;
    }
}
