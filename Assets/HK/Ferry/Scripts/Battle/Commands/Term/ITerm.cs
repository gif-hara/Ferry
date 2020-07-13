using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.CommandData.Terms
{
    /// <summary>
    /// コマンドを実行する条件を持つインターフェイス
    /// </summary>
    public interface ITerm
    {
        /// <summary>
        /// 説明文
        /// </summary>
        string Description { get; }

        /// <summary>
        /// コマンドを実行する対象
        /// </summary>
        TargetType TargetType { get; }

        /// <summary>
        /// <paramref name="targets"/>から条件を満たしているターゲットのみを返す
        /// </summary>
        IReadOnlyList<Actor> GetTargets(IReadOnlyList<Actor> targets);
    }
}
