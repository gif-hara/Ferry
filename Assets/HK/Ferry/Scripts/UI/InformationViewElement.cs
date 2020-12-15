using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class InformationViewElement : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textMesh = default;
        public TextMeshProUGUI TextMesh => textMesh;
    }
}
