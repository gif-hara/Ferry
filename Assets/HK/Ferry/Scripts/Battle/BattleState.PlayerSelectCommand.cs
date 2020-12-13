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
                        var arg = new PlayerInvokeCommand.Argument
                        {
                            command = x
                        };
                        owner.Change(BattleManager.BattlePhase.PlayerInvokeCommand, arg);
                    })
                    .AddTo(ActiveDisposables);
            }
        }
    }
}
