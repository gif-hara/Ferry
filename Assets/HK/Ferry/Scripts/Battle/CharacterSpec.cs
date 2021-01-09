using System;
using System.Collections.Generic;
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
        private CharacterStatus status = default;
        public CharacterStatus Status => status;

        [SerializeField]
        private List<SkillType> skillTypes = default;
        public List<SkillType> SkillTypes => skillTypes;

        public CharacterSpec(string name, CharacterStatus characterStatus, List<SkillType> skillTypes)
        {
            this.name = name;
            this.status = characterStatus;
            this.skillTypes = skillTypes;
        }

        public CharacterSpec(CharacterSpec other)
            : this(other.name, new CharacterStatus(other.status), other.skillTypes)
        {
        }
    }
}
