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
            public EnemyTurnEnd(BattleSystem battleManager) : base(battleManager)
            {
            }

            public override BattleSystem.BattlePhase StateName => BattleSystem.BattlePhase.EnemyTurnEnd;

            public override void Enter(StateController<BattleSystem.BattlePhase> owner, IStateArgument argument = null)
            {
                battleSystem.Enemy.EndTurn()
                    .Subscribe(_ =>
                    {
                        if (battleSystem.CanEnd())
                        {
                            owner.Change(BattleSystem.BattlePhase.End);
                        }
                        else
                        {
                            owner.Change(BattleSystem.BattlePhase.PlayerTurnStart);
                        }
                    })
                    .AddTo(ActiveDisposables);
            }
        }
    }
}
