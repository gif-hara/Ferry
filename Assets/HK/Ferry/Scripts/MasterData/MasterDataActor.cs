using System;
using HK.Ferry.ActorControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// アクターのデータを持つ<see cref="MasterData{T, R}"/>
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/Actor")]
    public sealed class MasterDataActor : MasterData<MasterDataActor, MasterDataActor.Record>
    {
        [Serializable]
        public sealed class Record : IIdHolder
        {
            [SerializeField]
            private int id = 0;

            [SerializeField]
            private ActorSpec spec = default;

            public int Id => this.id;

            public ActorSpec Spec => spec;
        }
    }
}
