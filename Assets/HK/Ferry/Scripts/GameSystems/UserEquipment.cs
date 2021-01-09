using HK.Ferry.Database;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserEquipment
    {
        public MasterDataEquipment.Record LeftHand { get; private set; }

        public MasterDataEquipment.Record RightHand { get; private set; }
    }
}
