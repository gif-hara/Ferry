using HK.Ferry.Database;
using HK.Ferry.FieldSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.GameSystems
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
                }

                return instance;
            }
        }

        public void SaveFieldStatus(int fieldDataId, FieldStatus fieldStatus)
        {
            PlayerPrefs.SetString(Key.GetFieldStatus(fieldDataId), fieldStatus.ToJson());
        }

        public FieldStatus LoadFieldStatus(int fieldDataId)
        {
            var fieldData = MasterDataFieldData.Get.GetRecord(fieldDataId).FieldData;
            if (PlayerPrefs.HasKey(Key.GetFieldStatus(fieldDataId)))
            {
                return new FieldStatus(PlayerPrefs.GetString(Key.GetFieldStatus(fieldDataId)));
            }

            return new FieldStatus(fieldData);
        }

        private static class Key
        {
            public static string GetFieldStatus(int fieldDataId)
            {
                return $"{nameof(FieldStatus)}[{fieldDataId}]";
            }
        }
    }
}
