using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// プレイヤーのターンを開始するステート
        /// </summary>
        public sealed class PlayerTurnStart : BattleStateBase
        {
            public PlayerTurnStart(BattleManager battleManager) : base(battleManager)
            {
            }

            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.PlayerTurnStart;

            public override void Enter(StateController<BattleManager.BattlePhase> owner, IStateArgument argument = null)
            {
                battleManager.Player.StartTurn();
                owner.Change(BattleManager.BattlePhase.PlayerSelectCommand);
            }
        }
    }
}
