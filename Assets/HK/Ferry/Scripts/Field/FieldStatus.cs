﻿using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace HK.Ferry.FieldSystems
{
    /// <summary>
    /// フィールドの状態を保持するクラス
    /// </summary>
    public sealed class FieldStatus
    {
        public readonly List<List<ReactiveProperty<Constants.IdentifyType>>> Identifies = new List<List<ReactiveProperty<Constants.IdentifyType>>>();

        public readonly List<List<ReactiveProperty<int>>> AccessCount = new List<List<ReactiveProperty<int>>>();

        public FieldStatus(FieldData fieldData)
        {
            for (var y = 0; y < fieldData.height; y++)
            {
                Identifies.Add(new List<ReactiveProperty<Constants.IdentifyType>>());
                AccessCount.Add(new List<ReactiveProperty<int>>());
                for (var x = 0; x < fieldData.width; x++)
                {
                    Identifies[y].Add(new ReactiveProperty<Constants.IdentifyType>(Constants.IdentifyType.Unidentify));
                    AccessCount[y].Add(new ReactiveProperty<int>(0));
                }
            }
        }

        public IReadOnlyReactiveProperty<Constants.IdentifyType> GetIdentifyAsObservable(int x, int y)
        {
            return Identifies[y][x];
        }

        public IReadOnlyReactiveProperty<int> GetAccessCountAsObservable(int x, int y)
        {
            return AccessCount[y][x];
        }

        [Serializable]
        public class SerializedData
        {
            public List<Constants.IdentifyType> identifies = new List<Constants.IdentifyType>();

            public int width;
        }
    }
}
