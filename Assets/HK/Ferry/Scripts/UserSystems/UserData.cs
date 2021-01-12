using HK.Ferry.Database;
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
                }

                return instance;
            }
        }

        public readonly UserFieldData FieldData = new UserFieldData();

        public readonly UserItem Item = new UserItem();

        public static class Key
        {
            public static string GetFieldStatus(int fieldDataId)
            {
                return $"{nameof(UserFieldData)}[{fieldDataId}]";
            }
        }
    }
}
