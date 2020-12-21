using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HK.Ferry.FieldSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class FieldManager : MonoBehaviour
    {
        [SerializeField]
        private FieldData debugFieldData = default;

        [SerializeField]
        private GridLayoutGroup gridLayoutGroup = default;

        [SerializeField]
        private FieldCellButtonController fieldCellButtonControllerPrefab = default;

        private void Start()
        {
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.constraintCount = debugFieldData.width;
            for (var y = 0; y < debugFieldData.height; y++)
            {
                for (var x = 0; x < debugFieldData.width; x++)
                {
                    var controller = Instantiate(fieldCellButtonControllerPrefab, gridLayoutGroup.transform, false);
                    controller.Button.OnClickAsObservable()
                        .Subscribe(_ =>
                        {
                            Debug.Log(debugFieldData);
                        })
                        .AddTo(controller);
                }
            }
        }
    }
}
