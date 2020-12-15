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
    }
}
