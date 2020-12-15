using HK.Ferry.BattleSystems;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using UnityEngine.UI;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class InformationView : MonoBehaviour
    {
        [SerializeField]
        private RectTransform elementRoot = default;

        [SerializeField]
        private InformationViewElement elementPrefab = default;

        [SerializeField]
        private ScrollRect scrollRect = default;

        public void Setup(BattleManager battleManager)
        {
            battleManager.LogsAsObservable()
                .ObserveAdd()
                .Subscribe(x =>
                {
                    var element = Instantiate(elementPrefab, elementRoot, false);
                    element.TextMesh.text = x.Value;
                    LayoutRebuilder.ForceRebuildLayoutImmediate(elementRoot);
                    scrollRect.verticalNormalizedPosition = 0.0f;
                })
                .AddTo(this);
        }
    }
}
