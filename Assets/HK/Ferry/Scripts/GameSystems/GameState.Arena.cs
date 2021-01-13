using HK.Ferry.ArenaSystems;
using HK.Ferry.Database;
using HK.Ferry.FieldSystems;
using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.GameSystems
{
    public partial class GameState
    {
        /// <summary>
        /// アリーナのステート
        /// </summary>
        public sealed class Arena : GameStateBase
        {
            public override GameManager.GameSystemType StateName => GameManager.GameSystemType.Arena;

            private ArenaSystem arenaSystemPrefab;

            private ArenaSystem arenaSystem;

            public Arena(GameManager gameManager, ArenaSystem arenaSystemPrefab) : base(gameManager)
            {
                this.arenaSystemPrefab = arenaSystemPrefab;
            }

            public override void Enter(StateController<GameManager.GameSystemType> owner, IStateArgument argument = null)
            {
                arenaSystem = Object.Instantiate(arenaSystemPrefab);
            }

            protected override void OnExit()
            {
                Object.Destroy(arenaSystem.gameObject);
                base.OnExit();
            }
        }
    }
}
