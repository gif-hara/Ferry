using System;
using HK.Ferry.Database;
using HK.Ferry.Extensions;
using UniRx;
using UnityEngine;

namespace HK.Ferry.FieldSystems.Events
{
    /// <summary>
    /// 移動することが出来ない<see cref="FieldEventBase"/>
    /// </summary>
    [Serializable]
    public sealed class Block : FieldEventBase
    {
        public override GameObject UIImagePrefab => MasterDataCellImage.Get.GetBlockRecord().CellImage;

        public override IDisposable Register(int x, int y, FieldStatus fieldStatus, FieldCellButtonController controller)
        {
            this.AddUIImage(controller);
            return Disposable.Empty;
        }
    }
}
