using System;
using HK.Ferry.Database;
using HK.Ferry.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.FieldSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class Log : FieldEventBase
    {
        [SerializeField]
        private string message = default;

        public override GameObject UIImagePrefab => MasterDataCellImage.Get.GetLogRecord().CellImage;

        public override Constants.IdentifyType OnIdentifiedType => Constants.IdentifyType.IdentifyPosible;

        public override IDisposable Register(int x, int y, FieldStatus fieldStatus, FieldCellButtonController controller)
        {
            this.AddUIImage(controller);
            return fieldStatus.GetAccessCountAsObservable(x, y)
                .Skip(1)
                .Where(accessed => accessed > 0)
                .Subscribe(_ =>
                {
                    Debug.Log(message);
                });
        }
    }
}
