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
        public void Save(int fieldDataId, FieldStatus fieldStatus)
        {
            PlayerPrefs.SetString(UserData.Key.GetFieldStatus(fieldDataId), fieldStatus.ToJson());
        }

        public FieldStatus Load(int fieldDataId)
        {
            var fieldData = MasterDataFieldData.Get.GetRecord(fieldDataId).FieldData;
            if (PlayerPrefs.HasKey(UserData.Key.GetFieldStatus(fieldDataId)))
            {
                return new FieldStatus(PlayerPrefs.GetString(UserData.Key.GetFieldStatus(fieldDataId)));
            }

            return new FieldStatus(fieldData);
        }
    }
}
