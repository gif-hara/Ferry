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
            public PlayerTurnStart(BattleSystem battleManager) : base(battleManager)
            {
            }

            public override BattleSystem.BattlePhase StateName => BattleSystem.BattlePhase.PlayerTurnStart;

            public override void Enter(StateController<BattleSystem.BattlePhase> owner, IStateArgument argument = null)
            {
                battleSystem.Player.StartTurn();
                owner.Change(BattleSystem.BattlePhase.PlayerSelectCommand);
            }
        }
    }
}
