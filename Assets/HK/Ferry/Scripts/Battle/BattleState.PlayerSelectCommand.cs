using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// プレイヤーがコマンドを選択するステート
        /// </summary>
        public sealed class PlayerSelectCommand : BattleStateBase
        {
            public PlayerSelectCommand(BattleManager battleManager) : base(battleManager)
            {
            }

            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.PlayerSelectCommand;

            public override void Enter(StateController<BattleManager.BattlePhase> owner, IStateArgument argument = null)
            {
                battleManager.UIView.SetCommandButtonInteractable(true);
                battleManager.UIView.SelectCommandAsObservable()
                    .Subscribe(x =>
                    {
                        var arg = new InvokeCommand.Argument
                        {
                            command = x.Command,
                            commandInvoker = battleManager.Player,
                            completeInvokeCommandAction = () => owner.Change(BattleManager.BattlePhase.PlayerTurnEnd)
                        };
                        x.ResetCoolTime();
                        owner.Change(BattleManager.BattlePhase.InvokeCommand, arg);
                    })
                    .AddTo(ActiveDisposables);
            }
        }
    }
}
