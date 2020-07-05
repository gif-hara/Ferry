using System;
using System.Collections.Generic;
using UnityEngine;

namespace HK.Ferry.Database
{
    /// <summary>
    /// パーティデータを持つ<see cref="MasterData{T, R}"/>
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/Party")]
    public sealed class MasterDataParty : MasterData<MasterDataParty, MasterDataParty.Record>
    {
        [Serializable]
        public sealed class Record : IIdHolder
        {
            [SerializeField]
            private int id = 0;

            [SerializeField]
            private List<int> actorIds = default;

            public int Id => this.id;

            public IReadOnlyList<int> ActorIds => actorIds;
        }
    }
}
