using System;
using System.Collections.Generic;
using HK.Ferry.AI;
using HK.Ferry.Database;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

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
            private CharacterStatus characterStatus = default;

            [SerializeField, TermsPopup]
            private List<string> commands = default;
            public List<string> Commands => commands;

            [SerializeField]
            private List<SkillType> skillTypes = default;

            public BattlePlayer CreateBattlePlayer()
            {
                var weapon = MasterDataEquipment.Get.GetRecord(weaponName);
                var instanceSkillTypes = new List<SkillType>(skillTypes);
                instanceSkillTypes.AddRange(weapon.Skills);
                var instanceCharacterStatus = new CharacterStatus(characterStatus);
                instanceCharacterStatus.Add(weapon);
                return new BattlePlayer(new CharacterSpec(name, weapon.AttackAttribute, instanceCharacterStatus, instanceSkillTypes), commands);
            }
        }
    }
}
