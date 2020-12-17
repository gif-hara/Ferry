using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using TMPro;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CommandButtonController : MonoBehaviour
    {
        [SerializeField]
        private Button button = default;
        public Button Button => button;

        [SerializeField]
        private TextMeshProUGUI text = default;
        public TextMeshProUGUI Text => text;

        private BattlePlayer.CommandData commandData;

        public void Setup(BattlePlayer.CommandData commandData)
        {
            this.commandData = commandData;
        }

        public void SetButtonInteractable(bool interactable)
        {
            button.interactable = interactable && commandData.CanUse;
        }
    }
}
