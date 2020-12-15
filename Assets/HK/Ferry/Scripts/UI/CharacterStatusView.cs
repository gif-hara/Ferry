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

        [SerializeField]
        private TextMeshProUGUI greatPowerText = default;

        [SerializeField]
        private TextMeshProUGUI artistPowerText = default;

        [SerializeField]
        private TextMeshProUGUI wisdomPowerText = default;

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
            battleCharacter.CurrentSpec.Status.greatPower
                .Subscribe(x =>
                {
                    greatPowerText.text = ScriptLocalization.UI.GreatPowerFormat.Format(x.ToString("0.00"));
                })
                .AddTo(this);
            battleCharacter.CurrentSpec.Status.artistPower
                .Subscribe(x =>
                {
                    artistPowerText.text = ScriptLocalization.UI.ArtistPowerFormat.Format(x.ToString("0.00"));
                })
                .AddTo(this);
            battleCharacter.CurrentSpec.Status.wisdomPower
                .Subscribe(x =>
                {
                    wisdomPowerText.text = ScriptLocalization.UI.WisdomPowerFormat.Format(x.ToString("0.00"));
                })
                .AddTo(this);
        }
    }
}
