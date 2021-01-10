using System;
using System.Collections.Generic;
using System.Linq;
using HK.Ferry.BattleSystems.Skills;
using UnityEngine;
using static HK.Ferry.Constants;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class CharacterSpec
    {
        [SerializeField]
        private string name = default;
        public string Name => name;

        [SerializeField]
        private AttackAttribute attackAttribute = default;
        public AttackAttribute AttackAttribute => attackAttribute;

        [SerializeField]
        private CharacterStatus status = default;
        public CharacterStatus Status => status;

        [SerializeField]
        private List<SkillType> skillTypes = default;
        public List<SkillType> SkillTypes => skillTypes;

        public CharacterSpec(string name, AttackAttribute attackAttribute, CharacterStatus characterStatus, List<SkillType> skillTypes)
        {
            this.name = name;
            this.attackAttribute = attackAttribute;
            this.status = characterStatus;
            this.skillTypes = skillTypes;
        }

        public CharacterSpec(CharacterSpec other)
            : this(other.name, other.attackAttribute, new CharacterStatus(other.status), other.skillTypes)
        {
        }

        public List<ISkill> CreateSkills()
        {
            return SkillTypes
                .GroupBy(x => x)
                .Select(x => SkillFactory.Create(x.Key, x.Count()))
                .ToList();
        }
    }
}
