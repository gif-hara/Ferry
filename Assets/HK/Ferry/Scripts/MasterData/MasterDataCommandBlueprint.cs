using System;
using HK.Ferry.CommandData;
using UnityEngine;

namespace HK.Ferry.Database
{
    /// <summary>
    /// <see cref="CommandBlueprint"/>データを持つ<see cref="MasterData{T, R}"/>
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/CommandBlueprint")]
    public sealed class MasterDataCommandBlueprint : MasterData<MasterDataCommandBlueprint, MasterDataCommandBlueprint.Record>
    {
        [Serializable]
        public sealed class Record : IIdHolder
        {
            [SerializeField]
            private int id = 0;

            [SerializeField]
            private CommandBlueprint blueprint = default;

            public int Id => this.id;

            public CommandBlueprint Blueprint => this.blueprint;
        }
    }
}
