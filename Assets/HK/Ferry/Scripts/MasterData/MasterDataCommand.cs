using System;
using HK.Ferry.BattleControllers;
using HK.Ferry.CommandData.Commands;
using UnityEngine;

namespace HK.Ferry.Database
{
    /// <summary>
    /// コマンドのデータを持つ<see cref="MasterData{T, R}"/>
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/Command")]
    public sealed class MasterDataCommand : MasterData<MasterDataCommand, MasterDataCommand.Record>
    {
        [Serializable]
        public sealed class Record : IIdHolder
        {
            [SerializeField]
            private int id = 0;

            [SerializeReference, SubclassSelector]
            private Command command = default;

            public int Id => this.id;

            public ICommand Command => this.command;
        }
    }
}
