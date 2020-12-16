using System;
using System.Collections.Generic;
using I2.Loc;
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
        private EnemyData enemy = default;
        public EnemyData Enemy => this.enemy;

        [SerializeField]
        private PlayerData player = default;
        public PlayerData Player => this.player;

        [Serializable]
        public sealed class EnemyData
        {
            [SerializeField]
            private CharacterSpec spec = default;
            public CharacterSpec Spec => spec;
        }

        [Serializable]
        public sealed class PlayerData
        {
            [SerializeField]
            private CharacterSpec spec = default;
            public CharacterSpec Spec => spec;

            [SerializeField, TermsPopup]
            private List<string> commands = default;
            public List<string> Commands => commands;
        }
    }
}
