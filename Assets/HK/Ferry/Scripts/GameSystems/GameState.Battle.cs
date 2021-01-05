using HK.Ferry.BattleSystems;
using HK.Ferry.Database;
using HK.Ferry.StateControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.GameSystems
{
    public partial class GameState
    {
        /// <summary>
        /// バトル開始のステート
        /// </summary>
        public sealed class Battle : GameStateBase
        {
            public override GameManager.GameSystemType StateName => GameManager.GameSystemType.Battle;

            private BattleSystem battleSystemPrefab;

            private BattleSystem battleSystem;

            public Battle(GameManager gameManager, BattleSystem battleSystem) : base(gameManager)
            {
                this.battleSystemPrefab = battleSystem;
            }

            public override void Enter(StateController<GameManager.GameSystemType> owner, IStateArgument argument = null)
            {
                this.battleSystem = Object.Instantiate(this.battleSystemPrefab);
                var arg = argument as Argument;
                if (arg != null)
                {
                    battleSystem.Setup(arg.enemyId);
                }
            }

            protected override void OnExit()
            {
                base.OnExit();
                Object.Destroy(this.battleSystem.gameObject);
            }

            public class Argument : IStateArgument
            {
                public int enemyId;
            }
        }
    }
}
