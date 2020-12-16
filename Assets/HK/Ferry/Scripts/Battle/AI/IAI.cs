using HK.Ferry.Database;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.AI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAI
    {
        MasterDataCommand.Record GetCommand();
    }
}
