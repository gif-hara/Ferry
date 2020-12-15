﻿using System;
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

        private ReactiveCollection<string> logs = new ReactiveCollection<string>();
        public IReadOnlyReactiveCollection<string> LogsAsObservable() => logs;

        private void Start()
        {
            Enemy = new BattleCharacter(debugBattleData.Enemy);
            Player = new BattleCharacter(debugBattleData.Player);
            uiView.Setup(this);

            stateController = new StateController<BattlePhase>(
                new List<IState<BattlePhase>>
                {
                    new BattleState.Begin(this),
                    new BattleState.PlayerSelectCommand(this),
                    new BattleState.PlayerInvokeCommand(this)
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
            return Observable.Concat(command.Commands.Select(x => x.Invoke(this, attacker, GetOpponent(attacker)))).AsSingleUnitObservable();
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
