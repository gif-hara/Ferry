using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// バトル開始のステート
        /// </summary>
        public sealed class PlayerSelectCommand : BattleStateBase
        {
            public PlayerSelectCommand(BattleManager battleManager) : base(battleManager)
            {
            }

            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.PlayerSelectCommand;

            public override void Enter(StateController<BattleManager.BattlePhase> owner)
            {
                Debug.Log("TODO PlayerSelectCommand");
                owner.Change(BattleManager.BattlePhase.PlayerInvokeCommand);
            }
        }
    }
}
