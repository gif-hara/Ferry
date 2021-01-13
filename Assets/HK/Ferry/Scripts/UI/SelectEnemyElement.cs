using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SelectEnemyElement : MonoBehaviour
    {
        [SerializeField]
        private Button button = default;
        public Button Button => button;

        [SerializeField]
        private TextMeshProUGUI text = default;
        public TextMeshProUGUI Text => text;
    }
}
