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
        private readonly Dictionary<string, int> itemNumbers = new Dictionary<string, int>();

        public UserItem()
        {
        }

        public UserItem(List<string> itemNames, List<int> itemNumbers)
        {
            Assert.AreEqual(itemNames.Count, itemNumbers.Count);
            for (var i = 0; i < itemNames.Count; i++)
            {
                this.itemNumbers.Add(itemNames[i], itemNumbers[i]);
            }
        }

        public void Serialize(Dictionary<string, string> serializeData)
        {
            var serializedData = new SerializedData()
            {
                itemNames = itemNumbers.Keys.ToList(),
                itemNumbers = itemNumbers.Values.ToList()
            };

            serializeData.Add(SerializedData.Key, JsonUtility.ToJson(serializedData));
        }

        public static UserItem Deserialize(Dictionary<string, string> serializeData)
        {
            var data = serializeData[SerializedData.Key];
            var serializedData = JsonUtility.FromJson<SerializedData>(data);

            return new UserItem(serializedData.itemNames, serializedData.itemNumbers);
        }

        public void Add(string itemName, int value)
        {
            if (itemNumbers.ContainsKey(itemName))
            {
                itemNumbers[itemName] += value;
            }
            else
            {
                itemNumbers.Add(itemName, value);
            }
        }

        public int Get(string itemName)
        {
            if (itemNumbers.ContainsKey(itemName))
            {
                return itemNumbers[itemName];
            }
            else
            {
                return 0;
            }
        }

        [Serializable]
        public class SerializedData
        {
            public List<string> itemNames;

            public List<int> itemNumbers;

            public static string Key => $"{nameof(UserItem)}";
        }
    }
}
