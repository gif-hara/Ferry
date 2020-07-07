using System;
using HK.Ferry.ActorControllers;
using HK.Ferry.BattleControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// コマンド実行条件のデータを持つ<see cref="MasterData{T, R}"/>
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/CommandComdition")]
    public sealed class MasterDataCommandCondition : MasterData<MasterDataCommandCondition, MasterDataCommandCondition.Record>
    {
        [Serializable]
        public sealed class Record : IIdHolder
        {
            [SerializeField]
            private int id = 0;

            [SerializeReference, SubclassSelector]
            private ICommandCondition condition = default;

            public int Id => this.id;

            public ICommandCondition Condition => this.condition;
        }
    }
}
