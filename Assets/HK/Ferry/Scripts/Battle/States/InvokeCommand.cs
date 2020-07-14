using HK.Ferry.StateControllers;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using HK.Ferry.ActorControllers;
using System.Linq;

namespace HK.Ferry.BattleControllers.States
{
    /// <summary>
    /// <see cref="Actor"/>がコマンドを実行するステート
    /// </summary>
    public sealed class InvokeCommand : IState
    {
        public CompositeDisposable Disposables { get; } = new CompositeDisposable();

        public string StateName => nameof(InvokeCommand);

        private readonly BattleEnvironment battleEnvironment;

        public InvokeCommand(BattleEnvironment battleEnvironment)
        {
            this.battleEnvironment = battleEnvironment;
        }

        public void Enter(StateController owner)
        {
            var actor = this.battleEnvironment.PlayerParty.Actors.FirstOrDefault(x => x.Status.IsEnoughTurnCharge);
            if (actor == null)
            {
                actor = this.battleEnvironment.EnemyParty.Actors.FirstOrDefault(x => x.Status.IsEnoughTurnCharge);
            }

            Assert.IsNotNull(actor, $"チャージ完了していないのに{nameof(InvokeCommand)}のステートになりました");

            actor.CommandController.Invoke(battleEnvironment)
                .Subscribe(_ =>
                {
                    var playerActors = this.battleEnvironment.PlayerParty.Actors;
                    var enemyActors = this.battleEnvironment.EnemyParty.Actors;
                    if (playerActors.Any(x => x.Status.IsEnoughTurnCharge) || enemyActors.Any(x => x.Status.IsEnoughTurnCharge))
                    {
                        owner.Change(nameof(InvokeCommand));
                    }
                    else
                    {
                        owner.Change(nameof(ProgressTurnCharge));
                    }
                });
        }

        public void Exit()
        {
        }
    }
}
