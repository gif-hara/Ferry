using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// 敵のターンを終了するステート
        /// </summary>
        public sealed class EnemyTurnEnd : BattleStateBase
        {
            public EnemyTurnEnd(BattleManager battleManager) : base(battleManager)
            {
            }

            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.EnemyTurnEnd;

            public override void Enter(StateController<BattleManager.BattlePhase> owner, IStateArgument argument = null)
            {
                owner.Change(BattleManager.BattlePhase.PlayerTurnStart);
            }
        }
    }
}
