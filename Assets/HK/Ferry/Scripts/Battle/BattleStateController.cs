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
        private Transform playerParent = default;

        [SerializeField]
        private Transform enemyParent = default;

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
                        this.playerParent,
                        this.debugBattleSetup.EnemyParty,
                        this.enemyParent,
                        this.actorPrefab
                        ),
                    new BattleStart()
                },
                nameof(CreateParties)
                );
        }
    }
}
