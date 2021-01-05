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
        public static bool IsSatisfy(this CompareType self, int a, int b)
        {
            switch (self)
            {
                case CompareType.Greater:
                    return a > b;
                case CompareType.GreaterEqual:
                    return a >= b;
                case CompareType.Lesser:
                    return a < b;
                case CompareType.LesserEqual:
                    return a <= b;
                case CompareType.Equal:
                    return a == b;
                default:
                    Assert.IsTrue(false, $"{self}は未対応です");
                    return false;
            }
        }

        public static Vector2Int AsVector2Int(this DirectionType directionType)
        {
            return new Vector2Int(
                directionType.IsLeft() ? -1 : directionType.IsRight() ? 1 : 0,
                directionType.IsTop() ? 1 : directionType.IsBottom() ? -1 : 0
                );
        }

        public static bool IsLeft(this DirectionType directionType)
        {
            return directionType.HasFlag(DirectionType.Left) || directionType.HasFlag(DirectionType.LeftTop) || directionType.HasFlag(DirectionType.LeftBottom);
        }

        public static bool IsRight(this DirectionType directionType)
        {
            return directionType.HasFlag(DirectionType.Right) || directionType.HasFlag(DirectionType.RightTop) || directionType.HasFlag(DirectionType.RightBottom);
        }

        public static bool IsTop(this DirectionType directionType)
        {
            return directionType.HasFlag(DirectionType.Top) || directionType.HasFlag(DirectionType.LeftTop) || directionType.HasFlag(DirectionType.RightTop);
        }

        public static bool IsBottom(this DirectionType directionType)
        {
            return directionType.HasFlag(DirectionType.Bottom) || directionType.HasFlag(DirectionType.LeftBottom) || directionType.HasFlag(DirectionType.RightBottom);
        }
    }
}
