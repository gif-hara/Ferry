using System.Collections.Generic;
using HK.Ferry.ArenaSystems;
using HK.Ferry.BattleSystems;
using HK.Ferry.FieldSystems;
using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.GameSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GameManager : MonoBehaviour
    {
        public enum GameSystemType
        {
            Field,
            Battle,
            Arena,
        }

        [SerializeField]
        private GameSystemType initialType = default;

        [SerializeField]
        private FieldSystem fieldSystemPrefab = default;

        [SerializeField]
        private BattleSystem battleSystemPrefab = default;

        [SerializeField]
        private ArenaSystem arenaSystemPrefab = default;

        public static GameManager Instance { get; private set; }

        private StateController<GameSystemType> stateController;
        public StateController<GameSystemType> StateController => stateController;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            stateController = new StateController<GameSystemType>(
                new List<IState<GameSystemType>>
                {
                    new GameState.Field(this, fieldSystemPrefab),
                    new GameState.Battle(this, battleSystemPrefab),
                    new GameState.Arena(this, arenaSystemPrefab)
                },
                initialType
                );
        }

        private void OnDestroy()
        {
            stateController.Dispose();
        }
    }
}
