using System.Collections.Generic;
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
        private StateController stateController;

        private void Start()
        {
            this.stateController = new StateController(
                new List<IState>
                {
                    new CreateParties(),
                    new BattleStart()
                },
                nameof(CreateParties)
                );
        }
    }
}
