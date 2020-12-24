using System;
using System.Collections.Generic;
using HK.Ferry.AI;
using HK.Ferry.Database;
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
        private int enemyId = default;
        public MasterDataEnemy.Record Enemy => MasterDataEnemy.Get.GetRecord(enemyId);

        [SerializeField]
        private PlayerData player = default;
        public PlayerData Player => this.player;

        [Serializable]
        public sealed class EnemyData
        {
            [SerializeField]
            private CharacterSpec spec = default;

            [SerializeField]
            private AIScriptableObject ai = default;

            public BattleEnemy CreateBattleEnemy()
            {
                return new BattleEnemy(spec, UnityEngine.Object.Instantiate(ai));
            }
        }

        [Serializable]
        public sealed class PlayerData
        {
            [SerializeField]
            private string name = default;

            [SerializeField, TermsPopup]
            private string weaponName = default;

            [SerializeField]
            private int hitPoint = default;

            [SerializeField]
            private float greatPower = default;

            [SerializeField]
            private float artistPower = default;

            [SerializeField]
            private float wisdomPower = default;

            [SerializeField, TermsPopup]
            private List<string> commands = default;
            public List<string> Commands => commands;

            public BattlePlayer CreateBattlePlayer()
            {
                var weapon = MasterDataWeapon.Get.GetRecord(weaponName);
                return new BattlePlayer(new CharacterSpec(name, new CharacterStatus(hitPoint, weapon.Attack, greatPower, artistPower, wisdomPower)), commands);
            }
        }
    }
}
