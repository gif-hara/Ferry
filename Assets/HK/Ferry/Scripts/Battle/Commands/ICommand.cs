using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// コマンドのデータを持つインターフェイス
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// コマンドを実行する
        /// </summary>
        void Invoke(IReadOnlyList<Actor> targets);
    }
}
