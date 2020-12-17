using System;
using UnityEngine;

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

        public CharacterSpec(string name, CharacterStatus characterStatus)
        {
            this.name = name;
            this.status = characterStatus;
        }

        public CharacterSpec(CharacterSpec other)
            : this(other.name, new CharacterStatus(other.status))
        {
        }
    }
}
