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
            public Begin(BattleSystem battleManager) : base(battleManager)
            {
            }

            public override BattleSystem.BattlePhase StateName => BattleSystem.BattlePhase.Begin;

            public override void Enter(StateController<BattleSystem.BattlePhase> owner, IStateArgument argument = null)
            {
                battleManager.UIView.EnemyStatusView.Setup(battleManager.Enemy);
                battleManager.UIView.PlayerStatusView.Setup(battleManager.Player);
                battleManager.UIView.CreateCommandButton(battleManager.Player.Commands);
                battleManager.UIView.SetCommandButtonInteractable(false);
                owner.Change(BattleSystem.BattlePhase.PlayerTurnStart);
            }
        }
    }
}
