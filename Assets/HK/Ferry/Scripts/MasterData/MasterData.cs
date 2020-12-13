using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MasterData<TMasterData, TRecord, TIdType> : ScriptableObject where TMasterData : MasterData<TMasterData, TRecord, TIdType>, new() where TRecord : IIdHolder<TIdType>
    {
        private static TMasterData instance;
        public static TMasterData Get
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<TMasterData>(ResourcePaths.Get(typeof(TMasterData)));
                    instance.Initialize();
                }

                return instance;
            }
        }

        [SerializeField]
        protected List<TRecord> records = default;

        public IReadOnlyList<TRecord> All => this.records;

        public TRecord GetRecord(TIdType id)
        {
            this.SetupCachedRecordTable();
            Assert.IsTrue(this.cachedRecordTable.ContainsKey(id), $"{typeof(TMasterData)}にid = {id}が存在しません");

            return this.cachedRecordTable[id];
        }

        public bool Contains(TIdType id)
        {
            this.SetupCachedRecordTable();

            return this.cachedRecordTable.ContainsKey(id);
        }

        protected virtual void Initialize()
        {
        }

        private void SetupCachedRecordTable()
        {
            if (this.cachedRecordTable != null)
            {
                return;
            }

            this.cachedRecordTable = new Dictionary<TIdType, TRecord>();
            foreach (var i in this.records)
            {
                Assert.IsFalse(this.cachedRecordTable.ContainsKey(i.Id), $"{typeof(TMasterData)}のId = {i.Id}が重複しました");
                this.cachedRecordTable.Add(i.Id, i);
            }
        }
        private Dictionary<TIdType, TRecord> cachedRecordTable = null;
    }
}
