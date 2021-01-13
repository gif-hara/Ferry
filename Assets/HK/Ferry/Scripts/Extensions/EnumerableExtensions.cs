using System.Collections.Generic;
using System.Linq;
using HK.Ferry.BattleSystems.Skills;
using UnityEngine;
using static HK.Ferry.Constants;

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

        public static List<Vector2Int> ExtractIndex<T>(this IReadOnlyList<IReadOnlyList<T>> self, Vector2Int center, params Constants.DirectionType[] directionTypes)
        {
            var result = new List<Vector2Int>();
            foreach (var i in directionTypes)
            {
                var position = center + i.AsVector2Int();
                if (position.y >= 0 && position.y < self.Count)
                {
                    var s = self[position.y];
                    if (position.x >= 0 && position.x < s.Count)
                    {
                        result.Add(position);
                    }
                }
            }

            return result;
        }


        public static int GetSkillLevel(this IList<ISkill> skills, SkillType skillType)
        {
            return skills
                .OfType<SkillTypeHolder>()
                .Where(x => x.SkillType == skillType)
                .Sum(x => x.Level);

        }

        public static SerializableDictionary<TKey, TValue> ToSerializable<TKey, TValue>(this IDictionary<TKey, TValue> self)
        {
            return new SerializableDictionary<TKey, TValue>(self);
        }
    }
}
