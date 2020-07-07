using System;
using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using HK.Ferry.BattleControllers.States;
using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// バトルのステートを管理するクラス
    /// </summary>
    public sealed class BattleStateController : MonoBehaviour
    {
        [SerializeField]
        private BattleSetup debugBattleSetup = default;

        [SerializeField]
        private BattleEnvironment battleEnvironment = default;

        [SerializeField]
        private Actor actorPrefab = default;

        private StateController stateController;

        private void Start()
        {
            this.stateController = new StateController(
                new List<IState>
                {
                    new CreateParties(
                        this.debugBattleSetup.PlayerParty,
                        this.battleEnvironment.PlayerParent,
                        this.debugBattleSetup.EnemyParty,
                        this.battleEnvironment.EnemyParent,
                        this.actorPrefab
                        ),
                    new BattleStart(),
                    new ProgressTurnCharge(this.battleEnvironment)
                },
                nameof(CreateParties)
                );
        }
    }
}
