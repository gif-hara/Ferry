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
        /// バトル開始のステート
        /// </summary>
        public sealed class Field : GameStateBase
        {
            public override GameManager.GameSystemType StateName => GameManager.GameSystemType.Field;

            private FieldSystem fieldSystemPrefab;

            private FieldSystem fieldSystem;

            public Field(GameManager gameManager, FieldSystem fieldSystem) : base(gameManager)
            {
                this.fieldSystemPrefab = fieldSystem;
            }

            public override void Enter(StateController<GameManager.GameSystemType> owner, IStateArgument argument = null)
            {
                this.fieldSystem = Object.Instantiate(fieldSystemPrefab);
            }

            protected override void OnExit()
            {
                base.OnExit();
                Object.Destroy(this.fieldSystem.gameObject);
            }
        }
    }
}
