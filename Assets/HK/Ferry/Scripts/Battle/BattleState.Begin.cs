using HK.Ferry.Database;
using HK.Ferry.StateControllers;
using UniRx;
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
                battleSystem.Player.StartBattle()
                    .Subscribe();
                battleSystem.Enemy.StartBattle()
                    .Subscribe();
                battleSystem.UIView.EnemyStatusView.Setup(battleSystem.Enemy);
                battleSystem.UIView.PlayerStatusView.Setup(battleSystem.Player);
                battleSystem.UIView.CreateCommandButton(battleSystem.Player.Commands);
                battleSystem.UIView.SetCommandButtonInteractable(false);
                owner.Change(BattleSystem.BattlePhase.PlayerTurnStart);
            }
        }
    }
}
