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
            public EnemyTurnStart(BattleSystem battleManager) : base(battleManager)
            {
            }

            public override BattleSystem.BattlePhase StateName => BattleSystem.BattlePhase.EnemyTurnStart;

            public override void Enter(StateController<BattleSystem.BattlePhase> owner, IStateArgument argument = null)
            {
                owner.Change(BattleSystem.BattlePhase.EnemySelectCommand);
            }
        }
    }
}
