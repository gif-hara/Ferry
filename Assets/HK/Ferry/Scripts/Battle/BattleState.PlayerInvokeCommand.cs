using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using HK.Ferry.Database;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// プレイヤーのコマンドを実行するステート
        /// </summary>
        public sealed class PlayerInvokeCommand : BattleStateBase
        {
            public PlayerInvokeCommand(BattleManager battleManager) : base(battleManager)
            {
            }

            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.PlayerInvokeCommand;

            public override void Enter(StateController<BattleManager.BattlePhase> owner, IStateArgument argument = null)
            {
                var arg = (Argument)argument;
                Assert.IsNotNull(arg);

                battleManager.UIView.SetCommandButtonInteractable(false);
                battleManager.InvokeCommand(battleManager.Player, arg.command)
                .Subscribe(x =>
                {
                    if (battleManager.CanEnd())
                    {
                        owner.Change(BattleManager.BattlePhase.End);
                    }
                }, () =>
                {
                    if (!battleManager.CanEnd())
                    {
                        owner.Change(BattleManager.BattlePhase.PlayerSelectCommand);
                    }
                })
                .AddTo(ActiveDisposables);
            }

            public class Argument : IStateArgument
            {
                public MasterDataCommand.Record command;
            }
        }
    }
}
