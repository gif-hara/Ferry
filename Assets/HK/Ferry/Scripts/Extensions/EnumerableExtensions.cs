using System.Collections.Generic;
using UnityEngine;

namespace HK.Ferry.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static List<T> Extract<T>(this IReadOnlyList<IReadOnlyList<T>> self, Vector2Int center, params Constants.DirectionType[] directionTypes)
        {
            var result = new List<T>();
            foreach (var i in directionTypes)
            {
                var position = center + i.AsVector2Int();
                if (position.y >= 0 && position.y < self.Count)
                {
                    var s = self[position.y];
                    if (position.x >= 0 && position.x < s.Count)
                    {
                        result.Add(s[position.x]);
                    }
                }
            }

            return result;
        }
    }
}
