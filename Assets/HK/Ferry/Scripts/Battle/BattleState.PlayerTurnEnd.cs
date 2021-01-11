using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// プレイヤーのターンを終了するステート
        /// </summary>
        public sealed class PlayerTurnEnd : BattleStateBase
        {
            public PlayerTurnEnd(BattleSystem battleManager) : base(battleManager)
            {
            }

            public override BattleSystem.BattlePhase StateName => BattleSystem.BattlePhase.PlayerTurnEnd;

            public override void Enter(StateController<BattleSystem.BattlePhase> owner, IStateArgument argument = null)
            {
                battleSystem.Player.EndTurn();
                owner.Change(BattleSystem.BattlePhase.EnemyTurnStart);
            }
        }
    }
}
