using HK.Ferry.Database;
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
        public sealed class Begin : BattleStateBase
        {
            public Begin(BattleManager battleManager) : base(battleManager)
            {
            }

            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.Begin;

            public override void Enter(StateController<BattleManager.BattlePhase> owner, IStateArgument argument = null)
            {
                var commands = MasterDataCommand.Get.GetRecords(battleManager.Player.Commands);
                battleManager.UIView.EnemyStatusView.Setup(battleManager.Enemy);
                battleManager.UIView.PlayerStatusView.Setup(battleManager.Player);
                battleManager.UIView.CreateCommandButton(commands);
                battleManager.UIView.SetCommandButtonInteractable(false);
                owner.Change(BattleManager.BattlePhase.PlayerSelectCommand);
            }
        }
    }
}
