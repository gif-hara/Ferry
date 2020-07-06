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
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public CompositeDisposable Disposables => disposables;

        public string StateName => nameof(BattleStart);

        public void Enter(StateController owner)
        {
            Debug.Log(nameof(BattleStart));
        }

        public void Exit()
        {
        }
    }
}
