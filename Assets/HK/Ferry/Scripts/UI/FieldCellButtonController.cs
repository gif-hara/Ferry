using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class FieldCellButtonController : MonoBehaviour
    {
        [SerializeField]
        private Button button = default;
        public Button Button => button;
    }
}
