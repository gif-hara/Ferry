using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MasterData<T, R> : ScriptableObject where T : MasterData<T, R>, new() where R : IIdHolder
    {
        private static T instance;
        public static T Get
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<T>(ResourcePaths.Get(typeof(T)));
                    instance.Initialize();
                }

                return instance;
            }
        }

        [SerializeField]
        protected List<R> records = default;

        public IReadOnlyList<R> All => this.records;

        public R GetRecord(int id)
        {
            this.SetupCachedRecordTable();
            Assert.IsTrue(this.cachedRecordTable.ContainsKey(id), $"{typeof(T)}にid = {id}が存在しません");

            return this.cachedRecordTable[id];
        }

        public bool Contains(int id)
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

            this.cachedRecordTable = new Dictionary<int, R>();
            foreach (var i in this.records)
            {
                Assert.IsFalse(this.cachedRecordTable.ContainsKey(i.Id), $"{typeof(T)}のId = {i.Id}が重複しました");
                this.cachedRecordTable.Add(i.Id, i);
            }
        }
        private Dictionary<int, R> cachedRecordTable = null;
    }
}
