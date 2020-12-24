﻿using System.Collections.Generic;
using HK.Ferry.Extensions;
using HK.Ferry.GameSystems;
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
    public sealed class FieldSystem : GameSystem
    {
        [SerializeField]
        private DebugFieldData debugFieldData = default;

        [SerializeField]
        private GridLayoutGroup gridLayoutGroup = default;

        [SerializeField]
        private ScrollRect scrollRect = default;

        [SerializeField]
        private FieldCellButtonController fieldCellButtonControllerPrefab = default;

        private List<List<FieldCellButtonController>> controllers = new List<List<FieldCellButtonController>>();

        private FieldData fieldData;

        private FieldStatus fieldStatus;

        private void Start()
        {
            fieldData = debugFieldData.fieldData;
            gridLayoutGroup.padding.left = Screen.width - (int)gridLayoutGroup.cellSize.x;
            gridLayoutGroup.padding.right = Screen.width - (int)gridLayoutGroup.cellSize.x;
            gridLayoutGroup.padding.top = Screen.height - (int)gridLayoutGroup.cellSize.y;
            gridLayoutGroup.padding.bottom = Screen.height - (int)gridLayoutGroup.cellSize.y;
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.constraintCount = fieldData.width;
            fieldStatus = new FieldStatus(fieldData);
            for (var y = 0; y < fieldData.height; y++)
            {
                controllers.Add(new List<FieldCellButtonController>());
                for (var x = 0; x < fieldData.width; x++)
                {
                    var controller = Instantiate(fieldCellButtonControllerPrefab, gridLayoutGroup.transform, false);
                    controllers[y].Add(controller);
                    var cellX = x;
                    var cellY = y;
                    controller.Button.OnClickAsObservable()
                        .Subscribe(_ =>
                        {
                            if (fieldStatus.GetIdentifyAsObservable(cellX, cellY).Value == IdentifyType.IdentifyPosible)
                            {
                                Identify(cellX, cellY);
                            }
                            else
                            {
                                fieldStatus.AccessCount[cellY][cellX].Value++;
                            }
                        })
                        .AddTo(controller);
                    fieldStatus.GetIdentifyAsObservable(x, y)
                        .Subscribe(type =>
                        {
                            controller.Button.interactable = type != Constants.IdentifyType.Unidentify;
                            controller.SetIdentifyTypeObject(type);
                        })
                        .AddTo(controller);
                }
            }

            foreach (var c in fieldData.cellDatas)
            {
                c.fieldEvent.Register(c.x, c.y, fieldStatus, controllers[c.y][c.x])
                    .AddTo(this);
            }

            Identify(debugFieldData.initialX, debugFieldData.initialY);
        }

        private void Identify(int x, int y)
        {
            fieldStatus.Identifies[y][x].Value = Constants.IdentifyType.Identify;
            foreach (var i in fieldStatus.Identifies.ExtractIndex(new Vector2Int(x, y), DirectionType.Left, DirectionType.Top, DirectionType.Right, DirectionType.Bottom))
            {
                var c = fieldStatus.Identifies[i.y][i.x];
                if (c.Value == IdentifyType.Unidentify)
                {
                    var cellData = fieldData.GetCellData(i.x, i.y);
                    if (cellData != null && cellData.fieldEvent.IsBlock())
                    {
                        c.Value = IdentifyType.Identify;
                    }
                    else
                    {
                        c.Value = IdentifyType.IdentifyPosible;
                    }
                }
            }
        }
    }
}
