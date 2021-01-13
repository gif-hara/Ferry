using System;
using System.Collections.Generic;
using System.Linq;
using HK.Ferry.Database;
using HK.Ferry.FieldSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.UserSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserFieldData
    {
        private Dictionary<int, FieldStatus> fieldStatues = new Dictionary<int, FieldStatus>();

        public UserFieldData()
        {
        }

        public UserFieldData(SerializableDictionary<int, string> fieldStatues)
        {
            this.fieldStatues = fieldStatues.ToDictionary().ToDictionary(x => x.Key, x => new FieldStatus(x.Value));
        }

        public void Serialize(Dictionary<string, string> serializeData)
        {
            var serializedData = new SerializedData()
            {
                fieldStatuses = new SerializableDictionary<int, string>(fieldStatues.ToDictionary(x => x.Key, x => x.Value.ToJson()))
            };

            serializeData.Add(SerializedData.Key, JsonUtility.ToJson(serializedData));
        }

        public static UserFieldData Deserialize(Dictionary<string, string> serializeData)
        {
            var data = serializeData[SerializedData.Key];

            return new UserFieldData(JsonUtility.FromJson<SerializedData>(data).fieldStatuses);
        }

        public FieldStatus Get(int fieldDataId)
        {
            if (fieldStatues.ContainsKey(fieldDataId))
            {
                return fieldStatues[fieldDataId];
            }

            var fieldData = MasterDataFieldData.Get.GetRecord(fieldDataId).FieldData;
            var result = new FieldStatus(fieldData);
            fieldStatues.Add(fieldDataId, result);
            return result;
        }

        [Serializable]
        public class SerializedData
        {
            public SerializableDictionary<int, string> fieldStatuses;

            public static string Key => nameof(UserFieldData);
        }
    }
}
