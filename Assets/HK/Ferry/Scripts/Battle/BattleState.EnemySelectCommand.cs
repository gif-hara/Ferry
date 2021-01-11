using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// 敵がコマンドを選択するステート
        /// </summary>
        public sealed class EnemySelectCommand : BattleStateBase
        {
            public EnemySelectCommand(BattleSystem battleManager) : base(battleManager)
            {
            }

            public override BattleSystem.BattlePhase StateName => BattleSystem.BattlePhase.EnemySelectCommand;

            public override void Enter(StateController<BattleSystem.BattlePhase> owner, IStateArgument argument = null)
            {
                var arg = new InvokeCommand.Argument
                {
                    command = battleSystem.Enemy.GetCommand(),
                    commandInvoker = battleSystem.Enemy,
                    completeInvokeCommandAction = () => owner.Change(BattleSystem.BattlePhase.EnemyTurnEnd)
                };
                owner.Change(BattleSystem.BattlePhase.InvokeCommand, arg);
            }
        }
    }
}
