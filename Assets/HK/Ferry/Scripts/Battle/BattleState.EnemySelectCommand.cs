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
            public EnemySelectCommand(BattleManager battleManager) : base(battleManager)
            {
            }

            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.EnemySelectCommand;

            public override void Enter(StateController<BattleManager.BattlePhase> owner, IStateArgument argument = null)
            {
                var command = battleManager.Enemy.GetCommand();
                Debug.Log($"TODO EnemySelectCommand Id = {command.Id}");

                owner.Change(BattleManager.BattlePhase.PlayerSelectCommand);
            }
        }
    }
}
