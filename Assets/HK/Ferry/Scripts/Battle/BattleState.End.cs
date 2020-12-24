using HK.Ferry.Database;
using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleSystems
{
    public partial class BattleState
    {
        /// <summary>
        /// バトル終了のステート
        /// </summary>
        public sealed class End : BattleStateBase
        {
            public End(BattleSystem battleManager) : base(battleManager)
            {
            }

            public override BattleSystem.BattlePhase StateName => BattleSystem.BattlePhase.End;

            public override void Enter(StateController<BattleSystem.BattlePhase> owner, IStateArgument argument = null)
            {
                Debug.Log("TODO End");
            }
        }
    }
}
