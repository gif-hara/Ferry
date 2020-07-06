using System;
using HK.Ferry.Database;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// バトルを行うのに必要なデータを持つクラス
    /// </summary>
    [Serializable]
    public sealed class BattleSetup
    {
        [SerializeField]
        private int playerPartyId = default;
        public int PlayerPartyId => this.playerPartyId;
        public MasterDataParty.Record PlayerParty => MasterDataParty.Get.GetRecord(this.playerPartyId);

        [SerializeField]
        private int enemyPartyId = default;
        public int EnemyPartyId => this.enemyPartyId;
        public MasterDataParty.Record EnemyParty => MasterDataParty.Get.GetRecord(this.enemyPartyId);
    }
}
