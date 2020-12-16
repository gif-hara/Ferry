using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static T Lottery<T>(this IReadOnlyCollection<T> self) where T : IWeight
        {
            var max = 0;
            foreach (var w in self)
            {
                max += w.Weight;
            }

            var current = 0;
            var random = Random.Range(0, max);
            foreach (var w in self)
            {
                if (random >= current && random < (current + w.Weight))
                {
                    return w;
                }

                current += w.Weight;
            }

            Assert.IsTrue(false, $"{nameof(Lottery)}の算出に失敗しました");
            return default;
        }
    }
}
