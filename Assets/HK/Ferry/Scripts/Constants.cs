using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public static class Constants
    {
        public enum PowerType
        {
            Great,
            Artist,
            Wisdom,
        }

        /// <summary>
        /// ターゲットタイプ
        /// </summary>
        public enum TargetType
        {
            /// <summary>
            /// 自分自身
            /// </summary>
            Myself,

            /// <summary>
            /// 相手
            /// </summary>
            Opponent,
        }

        /// <summary>
        /// 加算タイプ
        /// </summary>
        public enum AddType
        {
            /// <summary>
            /// 固定加算
            /// </summary>
            Fixed,

            /// <summary>
            /// 割合加算
            /// </summary>
            Percentage,

            /// <summary>
            /// 代入
            /// </summary>
            Set
        }
    }
}
