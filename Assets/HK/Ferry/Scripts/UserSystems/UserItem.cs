using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.UserSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserItem
    {
        private readonly Dictionary<int, int> itemNumbers = new Dictionary<int, int>();

        public UserItem()
        {
        }

        public UserItem(List<int> itemIds, List<int> itemNumbers)
        {
            Assert.AreEqual(itemIds.Count, itemNumbers.Count);
            for (var i = 0; i < itemIds.Count; i++)
            {
                this.itemNumbers.Add(itemIds[i], itemNumbers[i]);
            }
        }

        public void Serialize(Dictionary<string, string> serializeData)
        {
            var serializedData = new SerializedData()
            {
                itemIds = itemNumbers.Keys.ToList(),
                itemNumbers = itemNumbers.Values.ToList()
            };

            serializeData.Add(SerializedData.Key, JsonUtility.ToJson(serializedData));
        }

        public static UserItem Deserialize(Dictionary<string, string> serializeData)
        {
            var data = serializeData[SerializedData.Key];
            var serializedData = JsonUtility.FromJson<SerializedData>(data);

            return new UserItem(serializedData.itemIds, serializedData.itemNumbers);
        }

        public void Add(int itemId, int value)
        {
            if (itemNumbers.ContainsKey(itemId))
            {
                itemNumbers[itemId] += value;
            }
            else
            {
                itemNumbers.Add(itemId, value);
            }
        }

        public int Get(int itemId)
        {
            if (itemNumbers.ContainsKey(itemId))
            {
                return itemNumbers[itemId];
            }
            else
            {
                return 0;
            }
        }

        [Serializable]
        public class SerializedData
        {
            public List<int> itemIds;

            public List<int> itemNumbers;

            public static string Key => $"{nameof(UserItem)}";
        }
    }
}
