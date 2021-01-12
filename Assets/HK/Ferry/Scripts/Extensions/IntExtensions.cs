namespace HK.Ferry.Extensions
{
    /// <summary>
    /// <see cref="int"/>に関する拡張関数
    /// </summary>
    public static partial class Extensions
    {
        public static string AsItemNameLocalizeKey(this int self)
        {
            return $"Item/{self}";
        }
    }
}
