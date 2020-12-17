using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// 敵のターンを開始するステート
        /// </summary>
        public sealed class EnemyTurnStart : BattleStateBase
        {
            public EnemyTurnStart(BattleManager battleManager) : base(battleManager)
            {
            }

            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.EnemyTurnStart;

            public override void Enter(StateController<BattleManager.BattlePhase> owner, IStateArgument argument = null)
            {
                owner.Change(BattleManager.BattlePhase.EnemySelectCommand);
            }
        }
    }
}
