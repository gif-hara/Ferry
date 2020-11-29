using System.Collections.Generic;
using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// バトルを管理するクラス
    /// </summary>
    public sealed class BattleManager : MonoBehaviour
    {
        public enum BattlePhase
        {
            Begin,
            PlayerSelectCommand,
            PlayerInvokeCommand,
            EnemySelectCommand,
            EnemyInvokeCommand,
            Judgement,
            End,
        }

        private StateController<BattlePhase> stateController;

        private void Start()
        {
            this.stateController = new StateController<BattlePhase>(
                new List<IState<BattlePhase>>
                {
                    new BattleState.Begin(),
                    new BattleState.PlayerSelectCommand()
                },
                BattlePhase.Begin
                );
        }
    }
}
