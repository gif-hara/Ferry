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

        [SerializeField]
        private BattleUIView uiView = default;
        public BattleUIView UIView => uiView;

        [SerializeField]
        private DebugBattleData debugBattleData = default;

        public BattleCharacter Enemy { get; private set; }

        public BattleCharacter Player { get; private set; }

        private StateController<BattlePhase> stateController;

        private void Start()
        {
            Enemy = new BattleCharacter(debugBattleData.Enemy);
            Player = new BattleCharacter(debugBattleData.Player);

            this.stateController = new StateController<BattlePhase>(
                new List<IState<BattlePhase>>
                {
                    new BattleState.Begin(this),
                    new BattleState.PlayerSelectCommand(this)
                },
                BattlePhase.Begin
                );
        }
    }
}
