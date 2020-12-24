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
        public sealed class Field : GameStateBase
        {
            public override GameManager.GameSystemType StateName => GameManager.GameSystemType.Field;

            public override void Enter(StateController<GameManager.GameSystemType> owner, IStateArgument argument = null)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
