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

        public FieldStatus(string json)
        {
            var serializedData = JsonUtility.FromJson<SerializedData>(json);
            for (var y = 0; y < serializedData.height; y++)
            {
                Identifies.Add(new List<ReactiveProperty<Constants.IdentifyType>>());
                AccessCount.Add(new List<ReactiveProperty<int>>());
                for (var x = 0; x < serializedData.width; x++)
                {
                    var index = (y * serializedData.width) + x;
                    Identifies[y].Add(new ReactiveProperty<Constants.IdentifyType>(serializedData.identifies[index]));
                    AccessCount[y].Add(new ReactiveProperty<int>(serializedData.accessCount[index]));
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

        public string ToJson()
        {
            var serializedData = new SerializedData
            {
                identifies = Identifies.SelectMany(x => x.Select(y => y.Value)).ToList(),
                accessCount = AccessCount.SelectMany(x => x.Select(y => y.Value)).ToList(),
                width = Identifies[0].Count,
                height = Identifies.Count
            };

            return JsonUtility.ToJson(serializedData);
        }
    }

    [Serializable]
    public class SerializedData
    {
        public List<Constants.IdentifyType> identifies = new List<Constants.IdentifyType>();

        public List<int> accessCount = new List<int>();

        public int width;

        public int height;
    }
}
