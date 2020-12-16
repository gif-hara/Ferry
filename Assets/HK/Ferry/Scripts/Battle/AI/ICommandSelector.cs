using HK.Ferry.Database;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.AI
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommandSelector
    {
        MasterDataCommand.Record Get();
    }
}
