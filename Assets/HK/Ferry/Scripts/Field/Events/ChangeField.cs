using System;
using HK.Ferry.Database;
using HK.Ferry.Extensions;
using HK.Ferry.GameSystems;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.FieldSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class ChangeField : FieldEventBase
    {
        [SerializeField]
        private int fieldDataId = default;

        [SerializeField]
        private Vector2Int initialPosition = default;

        public override GameObject UIImagePrefab => MasterDataCellImage.Get.GetChangeFieldRecord().CellImage;

        public override IDisposable Register(int x, int y, FieldStatus fieldStatus, FieldCellButtonController controller)
        {
            this.AddUIImage(controller);
            return fieldStatus.GetAccessCountAsObservable(x, y)
                .Skip(1)
                .Where(accessed => accessed > 0)
                .Subscribe(_ =>
                {
                    GameManager.Instance.StateController.Change(GameManager.GameSystemType.Field, new GameState.Field.Argument { fieldDataId = fieldDataId, initialPosition = initialPosition });
                });
        }
    }
}
