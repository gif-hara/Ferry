﻿using UniRx;

namespace HK.Ferry.StateControllers
{
    /// <summary>
    /// ステートのインターフェイス
    /// </summary>
    public interface IState<TStateName>
    {
        void Enter(StateController<TStateName> owner);

        void Exit();

        CompositeDisposable Disposables { get; }

        TStateName StateName { get; }
    }
}
