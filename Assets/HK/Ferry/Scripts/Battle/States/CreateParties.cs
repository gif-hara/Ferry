using HK.Ferry.StateControllers;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers.States
{
    /// <summary>
    /// パーティを生成するステート
    /// </summary>
    public sealed class CreateParties : IState
    {
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public CompositeDisposable Disposables => disposables;

        public string StateName => nameof(CreateParties);

        public void Enter(StateController owner)
        {
            Debug.Log(nameof(CreateParties));

            owner.Change(nameof(BattleStart));
        }

        public void Exit()
        {
        }
    }
}
