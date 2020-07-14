using System;
using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using HK.Ferry.BattleControllers;
using HK.Ferry.CommandData.Terms;
using UniRx;

namespace HK.Ferry.CommandData.Commands
{
    /// <summary>
    /// コマンドのデータを持つインターフェイス
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// コマンドを実行する
        /// </summary>
        IObservable<Unit> Invoke(Actor invoker, IReadOnlyList<Actor> targets);

        /// <summary>
        /// このコマンドを実行可能なターゲットを返す
        /// </summary>
        IReadOnlyList<Actor> GetAvailableTargets(ITerm term, Actor invoker, BattleEnvironment battleEnvironment);
    }
}
