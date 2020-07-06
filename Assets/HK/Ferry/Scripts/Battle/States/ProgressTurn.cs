using HK.Ferry.StateControllers;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers.States
{
    /// <summary>
    /// アクターのターンゲージを更新するステート
    /// </summary>
    public sealed class ProgressTurn : IState
    {
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public CompositeDisposable Disposables => disposables;

        public string StateName => nameof(ProgressTurn);

        public void Enter(StateController owner)
        {
        }

        public void Exit()
        {
        }
    }
}
