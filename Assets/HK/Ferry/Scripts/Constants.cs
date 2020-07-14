using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public static class Constants
    {
        public enum TargetType
        {
            Ally,
            Opponent,
            My,
        }

        /// <summary>
        /// 攻撃属性
        /// </summary>
        public enum AttackAttribute
        {
            /// <summary>
            /// 物理
            /// </summary>
            Physical,

            /// <summary>
            /// 魔法
            /// </summary>
            Magic,
        }

        /// <summary>
        /// 属性
        /// </summary>
        public enum ElementAttribute
        {
            No,
            Fire,
            Water,
            Wood,
        }
    }
}
