using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// バトルの中枢を担うクラス
    /// </summary>
    public sealed class BattleManager : MonoBehaviour
    {
        [SerializeField]
        private BattleStateController stateController = default;

        private void Start()
        {
            this.stateController.Setup();
        }
    }
}
