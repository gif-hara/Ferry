using System.Collections.Generic;
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
        }

        [SerializeField]
        private GameSystemType initialType = default;

        [SerializeField]
        private FieldSystem fieldSystemPrefab = default;

        [SerializeField]
        private BattleSystem battleSystemPrefab = default;

        public static GameManager Instance { get; private set; }

        private StateController<GameSystemType> stateController;

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
                    new GameState.Battle(this, battleSystemPrefab)
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
