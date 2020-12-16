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
        public static string AsLocalize(this PowerType self)
        {
            switch (self)
            {
                case PowerType.Great:
                    return ScriptLocalization.UI.GreatPower;
                case PowerType.Artist:
                    return ScriptLocalization.UI.ArtistPower;
                case PowerType.Wisdom:
                    return ScriptLocalization.UI.WisdomPower;
                default:
                    Assert.IsTrue(false, $"{self}は未対応です");
                    return "";
            }
        }

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
    }
}
