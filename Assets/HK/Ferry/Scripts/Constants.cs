using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public static class Constants
    {
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

        public enum CompareType
        {
            /// <summary>
            /// a > b
            /// </summary>
            Greater,

            /// <summary>
            /// a >= b
            /// </summary>
            GreaterEqual,

            /// <summary>
            /// a < b
            /// </summary>
            Lesser,

            /// <summary>
            /// a <= b
            /// </summary>
            LesserEqual,

            /// <summary>
            /// a == b
            /// </summary>
            Equal,
        }

        /// <summary>
        /// 識別タイプ
        /// </summary>
        public enum IdentifyType
        {
            /// <summary>
            /// 未識別
            /// </summary>
            Unidentify,

            /// <summary>
            /// 識別可能
            /// </summary>
            IdentifyPosible,

            /// <summary>
            /// 識別
            /// </summary>
            Identify,
        }

        [Flags]
        public enum DirectionType
        {
            LeftTop = 1,
            Top = 1 << 1,
            RightTop = 1 << 2,
            Right = 1 << 3,
            RightBottom = 1 << 4,
            Bottom = 1 << 5,
            LeftBottom = 1 << 6,
            Left = 1 << 7
        }
    }
}
