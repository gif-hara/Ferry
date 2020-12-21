using HK.Ferry.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using static HK.Ferry.Constants;

namespace HK.Ferry.FieldSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class FieldManager : MonoBehaviour
    {
        [SerializeField]
        private DebugFieldData debugFieldData = default;

        [SerializeField]
        private GridLayoutGroup gridLayoutGroup = default;

        [SerializeField]
        private ScrollRect scrollRect = default;

        [SerializeField]
        private FieldCellButtonController fieldCellButtonControllerPrefab = default;

        private FieldStatus fieldStatus;

        private void Start()
        {
            gridLayoutGroup.padding.left = Screen.width - (int)gridLayoutGroup.cellSize.x;
            gridLayoutGroup.padding.right = Screen.width - (int)gridLayoutGroup.cellSize.x;
            gridLayoutGroup.padding.top = Screen.height - (int)gridLayoutGroup.cellSize.y;
            gridLayoutGroup.padding.bottom = Screen.height - (int)gridLayoutGroup.cellSize.y;
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.constraintCount = debugFieldData.fieldData.width;
            fieldStatus = new FieldStatus(debugFieldData.fieldData);
            for (var y = 0; y < debugFieldData.fieldData.height; y++)
            {
                for (var x = 0; x < debugFieldData.fieldData.width; x++)
                {
                    var controller = Instantiate(fieldCellButtonControllerPrefab, gridLayoutGroup.transform, false);
                    var cellX = x;
                    var cellY = y;
                    controller.Button.OnClickAsObservable()
                        .Subscribe(_ =>
                        {
                            if (fieldStatus.GetIdentify(cellX, cellY).Value == IdentifyType.IdentifyPosible)
                            {
                                Identify(cellX, cellY);
                            }
                            else
                            {
                                fieldStatus.Accessed[cellY][cellX].Value = true;
                            }
                        })
                        .AddTo(controller);
                    fieldStatus.GetIdentify(x, y)
                        .Subscribe(type =>
                        {
                            controller.Button.interactable = type != Constants.IdentifyType.Unidentify;
                            controller.SetIdentifyTypeObject(type);
                        })
                        .AddTo(controller);
                    fieldStatus.GetAccessed(x, y)
                        .Skip(1)
                        .Where(accessed => accessed)
                        .Subscribe(_ =>
                        {
                            Debug.Log($"({cellX}, {cellY}) Accessed");
                        })
                        .AddTo(controller);
                }
            }

            Identify(debugFieldData.initialX, debugFieldData.initialY);
        }

        private void Identify(int x, int y)
        {
            fieldStatus.Identifies[y][x].Value = Constants.IdentifyType.Identify;
            foreach (var c in fieldStatus.Identifies.Extract(new Vector2Int(x, y), DirectionType.Left, DirectionType.Top, DirectionType.Right, DirectionType.Bottom))
            {
                if (c.Value == IdentifyType.Unidentify)
                {
                    c.Value = IdentifyType.IdentifyPosible;
                }
            }
        }
    }
}
