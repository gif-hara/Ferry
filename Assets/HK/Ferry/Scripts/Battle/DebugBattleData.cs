using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class DebugBattleData
    {
        [SerializeField]
        private CharacterSpec enemy = default;
        public CharacterSpec Enemy => this.enemy;

        [SerializeField]
        private CharacterSpec player = default;
        public CharacterSpec Player => this.player;
    }
}
