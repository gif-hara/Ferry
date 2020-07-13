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
            if (type == typeof(MasterDataCommandBlueprint)) return "MasterData/CommandBlueprint";
            if (type == typeof(MasterDataCommand)) return "MasterData/Command";
            if (type == typeof(MasterDataCommandTerm)) return "MasterData/CommandTerm";

            Assert.IsTrue(false, $"{type}は未対応です");
            return "";
        }
    }
}
