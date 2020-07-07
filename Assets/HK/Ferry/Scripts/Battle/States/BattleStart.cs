using HK.Ferry.StateControllers;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers.States
{
    /// <summary>
    /// バトルを開始するステート
    /// </summary>
    public sealed class BattleStart : IState
    {
        public CompositeDisposable Disposables { get; } = new CompositeDisposable();

        public string StateName => nameof(BattleStart);

        public void Enter(StateController owner)
        {
            owner.Change(nameof(ProgressTurnCharge));
        }

        public void Exit()
        {
        }
    }
}
