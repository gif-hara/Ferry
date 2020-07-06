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
            if (type == typeof(MasterDataParty)) return "MasterData/Party";
            if (type == typeof(MasterDataActor)) return "MasterData/Actor";

            Assert.IsTrue(false, $"{type}は未対応です");
            return "";
        }
    }
}
