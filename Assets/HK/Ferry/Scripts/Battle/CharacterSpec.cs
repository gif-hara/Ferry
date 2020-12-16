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

        public CharacterSpec(CharacterSpec other)
        {
            name = other.name;
            status = new CharacterStatus(other.status);
        }
    }
}
