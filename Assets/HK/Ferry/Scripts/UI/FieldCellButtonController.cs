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

        [SerializeField]
        private GameObject unidentifyObject = default;

        [SerializeField]
        private GameObject identifyPosibleObject = default;

        [SerializeField]
        private GameObject identifyObject = default;

        public void SetIdentifyTypeObject(Constants.IdentifyType identifyType)
        {
            unidentifyObject.SetActive(identifyType == Constants.IdentifyType.Unidentify);
            identifyPosibleObject.SetActive(identifyType == Constants.IdentifyType.IdentifyPosible);
            identifyObject.SetActive(identifyType == Constants.IdentifyType.Identify);
        }
    }
}
