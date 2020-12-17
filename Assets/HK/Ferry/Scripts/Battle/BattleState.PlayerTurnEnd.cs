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
            public PlayerTurnEnd(BattleManager battleManager) : base(battleManager)
            {
            }

            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.PlayerTurnEnd;

            public override void Enter(StateController<BattleManager.BattlePhase> owner, IStateArgument argument = null)
            {
                owner.Change(BattleManager.BattlePhase.EnemyTurnStart);
            }
        }
    }
}
