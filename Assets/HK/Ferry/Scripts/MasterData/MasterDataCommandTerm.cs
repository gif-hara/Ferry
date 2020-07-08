using System;
using HK.Ferry.CommandData.Terms;
using UnityEngine;

namespace HK.Ferry.Database
{
    /// <summary>
    /// コマンド実行条件のデータを持つ<see cref="MasterData{T, R}"/>
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/CommandTerm")]
    public sealed class MasterDataCommandTerm : MasterData<MasterDataCommandTerm, MasterDataCommandTerm.Record>
    {
        [Serializable]
        public sealed class Record : IIdHolder
        {
            [SerializeField]
            private int id = 0;

            [SerializeReference, SubclassSelector]
            private ITerm condition = default;

            public int Id => this.id;

            public ITerm Condition => this.condition;
        }
    }
}
