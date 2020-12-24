using System;
using HK.Ferry.Database;
using HK.Ferry.GameSystems;
using HK.Ferry.StateControllers;
using UniRx;
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
                battleManager.AddLog("TODO:バトル終了");

                Observable.Timer(TimeSpan.FromSeconds(3.0f))
                    .Subscribe(_ =>
                    {
                        GameManager.Instance.StateController.Change(GameManager.GameSystemType.Field);
                    });
            }
        }
    }
}
