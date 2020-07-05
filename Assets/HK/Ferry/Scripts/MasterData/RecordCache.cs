using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class RecordCache<Type, Record>
    {
        private readonly Dictionary<Type, Record> cache = new Dictionary<Type, Record>();

        public RecordCache(IReadOnlyList<Record> records, Func<Record, Type> keySelector)
        {
            foreach (var i in records)
            {
                var key = keySelector(i);
                Assert.IsFalse(this.cache.ContainsKey(key));

                this.cache.Add(key, i);
            }
        }

        public Record Get(Type key)
        {
            Assert.IsTrue(this.cache.ContainsKey(key));

            return this.cache[key];
        }
    }
}
