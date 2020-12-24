using System;
using System.Collections.Generic;
using HK.Ferry.FieldSystems;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/FieldData")]
    public sealed class MasterDataFieldData : MasterData<MasterDataFieldData, MasterDataFieldData.Record, int>
    {
        [Serializable]
        public class Record : IIdHolder<int>
        {
            [SerializeField]
            private int id = default;

            public int Id => id;

            [SerializeField]
            private FieldData fieldData = default;
            public FieldData FieldData => fieldData;
        }
    }
}
