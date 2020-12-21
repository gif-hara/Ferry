using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace HK.Ferry.FieldSystems
{
    /// <summary>
    /// フィールドの識別状態を保持するクラス
    /// </summary>
    public sealed class FieldIdentify
    {
        public readonly List<List<ReactiveProperty<Constants.IdentifyType>>> Identifies = new List<List<ReactiveProperty<Constants.IdentifyType>>>();

        public FieldIdentify(FieldData fieldData)
        {
            for (var y = 0; y < fieldData.height; y++)
            {
                Identifies.Add(new List<ReactiveProperty<Constants.IdentifyType>>());
                for (var x = 0; x < fieldData.width; x++)
                {
                    Identifies[y].Add(new ReactiveProperty<Constants.IdentifyType>(Constants.IdentifyType.Unidentify));
                }
            }

            var serializedData = new SerializedData
            {
                identifies = this.Identifies.SelectMany(x => x.Select(y => y.Value)).ToList(),
                width = fieldData.width
            };

            var json = JsonUtility.ToJson(serializedData);
            Debug.Log(json);
        }

        public IReadOnlyReactiveProperty<Constants.IdentifyType> Get(int x, int y)
        {
            return Identifies[y][x];
        }

        public void Set(int x, int y, Constants.IdentifyType identifyType)
        {
            Identifies[y][x].Value = identifyType;
        }

        [Serializable]
        public class SerializedData
        {
            public List<Constants.IdentifyType> identifies = new List<Constants.IdentifyType>();

            public int width;
        }
    }
}
