using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UniRx;
using I2.Loc;
using HK.Ferry.Extensions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CharacterStatusView : MonoBehaviour
    {
        [SerializeField]
        private Slider hitPointSlider = default;

        [SerializeField]
        private TextMeshProUGUI hitPointText = default;

        [SerializeField]
        private TextMeshProUGUI attackText = default;

        public void Setup(BattleCharacter battleCharacter)
        {
            battleCharacter.CurrentSpec.Status.hitPoint
                .Subscribe(x =>
                {
                    hitPointSlider.value = battleCharacter.HitPointRate;
                    hitPointText.text = x.ToString();
                })
                .AddTo(this);
            battleCharacter.CurrentSpec.Status.attack
                .Subscribe(x =>
                {
                    attackText.text = ScriptLocalization.UI.AttackFormat.Format(x.ToString());
                })
                .AddTo(this);
        }
    }
}
