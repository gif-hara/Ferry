using System;
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

        public readonly List<List<ReactiveProperty<bool>>> Accessed = new List<List<ReactiveProperty<bool>>>();

        public FieldStatus(FieldData fieldData)
        {
            for (var y = 0; y < fieldData.height; y++)
            {
                Identifies.Add(new List<ReactiveProperty<Constants.IdentifyType>>());
                Accessed.Add(new List<ReactiveProperty<bool>>());
                for (var x = 0; x < fieldData.width; x++)
                {
                    Identifies[y].Add(new ReactiveProperty<Constants.IdentifyType>(Constants.IdentifyType.Unidentify));
                    Accessed[y].Add(new ReactiveProperty<bool>(false));
                }
            }
        }

        public IReadOnlyReactiveProperty<Constants.IdentifyType> GetIdentify(int x, int y)
        {
            return Identifies[y][x];
        }

        public IReadOnlyReactiveProperty<bool> GetAccessed(int x, int y)
        {
            return Accessed[y][x];
        }

        [Serializable]
        public class SerializedData
        {
            public List<Constants.IdentifyType> identifies = new List<Constants.IdentifyType>();

            public int width;
        }
    }
}
