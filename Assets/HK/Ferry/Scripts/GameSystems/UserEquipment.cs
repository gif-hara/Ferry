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
        public MasterDataWeapon.Record LeftHand { get; private set; }

        public MasterDataWeapon.Record RightHand { get; private set; }
    }
}
