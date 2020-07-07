using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HK.Ferry.ActorControllers;
using HK.Ferry.StateControllers;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers.States
{
    /// <summary>
    /// アクターのターンゲージを更新するステート
    /// </summary>
    public sealed class ProgressTurnCharge : IState
    {
        public CompositeDisposable Disposables { get; } = new CompositeDisposable();

        public string StateName => nameof(ProgressTurnCharge);

        private readonly BattleEnvironment battleEnvironment;

        public ProgressTurnCharge(BattleEnvironment battleEnvironment)
        {
            this.battleEnvironment = battleEnvironment;
        }

        public void Enter(StateController owner)
        {
            Observable.EveryGameObjectUpdate()
                .Subscribe(_ =>
                {
                    Debug.Log("Update");
                    var playerActors = this.battleEnvironment.PlayerParty.Actors;
                    var enemyActors = this.battleEnvironment.EnemyParty.Actors;
                    UpdateTurnCharge(playerActors);
                    UpdateTurnCharge(enemyActors);

                    if (playerActors.Any(x => x.Status.IsEnoughTurnCharge) || enemyActors.Any(x => x.Status.IsEnoughTurnCharge))
                    {
                        owner.Change(nameof(InvokeCommand));
                    }
                })
                .AddTo(this.Disposables);
        }

        public void Exit()
        {
        }

        private static void UpdateTurnCharge(IEnumerable<Actor> actors)
        {
            foreach (var a in actors)
            {
                a.Status.UpdateTurnCharge();
            }
        }
    }
}
