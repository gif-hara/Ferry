using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/CellImage")]
    public sealed class MasterDataCellImage : MasterData<MasterDataCellImage, MasterDataCellImage.Record, int>
    {
        [Serializable]
        public class Record : IIdHolder<int>
        {
            [SerializeField]
            private int id = default;

            public int Id => id;

            [SerializeField]
            private GameObject cellImage;

            public GameObject CellImage => cellImage;
        }

        public Record GetBlockRecord()
        {
            return GetRecord(100100);
        }

        public Record GetLogRecord()
        {
            return GetRecord(100200);
        }

        public Record GetEnemyRecord()
        {
            return GetRecord(100300);
        }
    }
}
