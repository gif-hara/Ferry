using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using HK.Ferry.Database;
using System;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// コマンドを実行するステート
        /// </summary>
        public sealed class InvokeCommand : BattleStateBase
        {
            public InvokeCommand(BattleSystem battleManager) : base(battleManager)
            {
            }

            public override BattleSystem.BattlePhase StateName => BattleSystem.BattlePhase.InvokeCommand;

            public override void Enter(StateController<BattleSystem.BattlePhase> owner, IStateArgument argument = null)
            {
                var arg = (Argument)argument;
                Assert.IsNotNull(arg);

                battleSystem.UIView.SetCommandButtonInteractable(false);
                battleSystem.InvokeCommand(arg.commandInvoker, arg.command)
                .Subscribe(x =>
                {
                    if (battleSystem.CanEnd())
                    {
                        owner.Change(BattleSystem.BattlePhase.End);
                    }
                }, () =>
                {
                    if (!battleSystem.CanEnd())
                    {
                        arg.completeInvokeCommandAction();
                    }
                })
                .AddTo(ActiveDisposables);
            }

            public class Argument : IStateArgument
            {
                public MasterDataCommand.Record command;

                public BattleCharacter commandInvoker;

                public Action completeInvokeCommandAction;
            }
        }
    }
}
