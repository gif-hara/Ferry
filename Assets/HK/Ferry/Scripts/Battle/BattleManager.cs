using System;
using System.Collections.Generic;
using System.Linq;
using HK.Ferry.Database;
using HK.Ferry.StateControllers;
using UniRx;
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
            EnemySelectCommand,
            InvokeCommand,
            End,
        }

        [SerializeField]
        private BattleUIView uiView = default;
        public BattleUIView UIView => uiView;

        [SerializeField]
        private DebugBattleData debugBattleData = default;

        public BattleEnemy Enemy { get; private set; }

        public BattlePlayer Player { get; private set; }

        private StateController<BattlePhase> stateController;

        private ReactiveCollection<string> logs = new ReactiveCollection<string>();
        public IReadOnlyReactiveCollection<string> LogsAsObservable() => logs;

        private void Start()
        {
            Enemy = new BattleEnemy(debugBattleData.Enemy.Spec, debugBattleData.Enemy.AI);
            Player = new BattlePlayer(debugBattleData.Player.Spec, debugBattleData.Player.Commands);
            uiView.Setup(this);

            stateController = new StateController<BattlePhase>(
                new List<IState<BattlePhase>>
                {
                    new BattleState.Begin(this),
                    new BattleState.PlayerSelectCommand(this),
                    new BattleState.EnemySelectCommand(this),
                    new BattleState.InvokeCommand(this),
                    new BattleState.End(this)
                },
                BattlePhase.Begin
                );
        }

        private void OnDestroy()
        {
            stateController.Dispose();
        }

        public IObservable<Unit> InvokeCommand(BattleCharacter attacker, MasterDataCommand.Record command)
        {
            return Observable.Concat(command.Commands.Select(x => x.Invoke(this, attacker, GetOpponent(attacker))));
        }

        public BattleCharacter GetOpponent(BattleCharacter battleCharacter)
        {
            if (battleCharacter == Enemy)
            {
                return Player;
            }
            else if (battleCharacter == Player)
            {
                return Enemy;
            }

            Assert.IsTrue(false, $"{battleCharacter}は未対応です");
            return null;
        }

        public void AddLog(string log)
        {
            logs.Add(log);
        }

        /// <summary>
        /// バトルを終了できるか返す
        /// </summary>
        public bool CanEnd()
        {
            return Enemy.IsDead || Player.IsDead;
        }

        [ContextMenu("Set All Command")]
        private void SetAllCommand()
        {
            debugBattleData.Player.Commands.Clear();
            foreach (var record in MasterDataCommand.Get.All)
            {
                debugBattleData.Player.Commands.Add(record.Id);
            }
        }
    }
}
