using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// 
    /// </summary>
    public static class ResourcePaths
    {
        public static string Get(Type type)
        {
            if (type == typeof(MasterDataCommand)) return "MasterData/Command";
            if (type == typeof(MasterDataWeapon)) return "MasterData/Weapon";

            Assert.IsTrue(false, $"{type}は未対応です");
            return "";
        }
    }
}
