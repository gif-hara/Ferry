using HK.Ferry.StateControllers;
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
            public override BattleManager.BattlePhase StateName => BattleManager.BattlePhase.Begin;

            public override void Enter(StateController<BattleManager.BattlePhase> owner)
            {
                Debug.Log("TODO Begin");
                owner.Change(BattleManager.BattlePhase.PlayerSelectCommand);
            }
        }
    }
}
