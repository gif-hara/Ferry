using System.Collections.Generic;
using HK.Ferry.Database;
using HK.Ferry.Extensions;
using HK.Ferry.FieldSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.UserSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserData
    {
        private static UserData instance = null;
        public static UserData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserData();

                    if (PlayerPrefs.HasKey(SerializedData.Key))
                    {
                        var serializedData = JsonUtility.FromJson<SerializedData>(PlayerPrefs.GetString(SerializedData.Key));
                        var saveData = serializedData.saveData.ToDictionary();
                        instance.fieldData = UserFieldData.Deserialize(saveData);
                        instance.item = UserItem.Deserialize(saveData);
                    }
                }

                return instance;
            }
        }

        private UserFieldData fieldData = new UserFieldData();
        public UserFieldData FieldData => fieldData;

        private UserItem item = new UserItem();
        public UserItem Item => item;

        public void Save()
        {
            var saveDara = new Dictionary<string, string>();
            FieldData.Serialize(saveDara);
            Item.Serialize(saveDara);
            var serializedData = new SerializedData()
            {
                saveData = saveDara.ToSerializable()
            };

            PlayerPrefs.SetString(SerializedData.Key, JsonUtility.ToJson(serializedData));
        }

        public static class Key
        {
            public static string GetFieldStatus(int fieldDataId)
            {
                return $"{nameof(UserFieldData)}[{fieldDataId}]";
            }
        }

        public class SerializedData
        {
            public SerializableDictionary<string, string> saveData;

            public static string Key => nameof(UserData);
        }
    }
}
