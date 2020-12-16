using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.AI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOwner
    {
        /// <summary>
        /// <see cref="IOwner"/>がアクティブになってから経過したターン数
        /// </summary>
        int ElapsedTurn { get; }
    }
}
