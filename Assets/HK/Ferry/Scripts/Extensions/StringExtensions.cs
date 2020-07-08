namespace HK.Ferry.Extensions
{
    /// <summary>
    /// <see cref="string"/>に関する拡張関数
    /// </summary>
    public static partial class Extensions
    {
        public static string AsLocalize(this string self)
        {
            return I2.Loc.LocalizationManager.GetTranslation(self);
        }
    }
}
