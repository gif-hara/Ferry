using System;
using HK.Ferry.BattleSystems;
using HK.Ferry.Extensions;
using I2.Loc;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class AddPower : ICommand
    {
        [SerializeField]
        private PowerType powerType = default;

        [SerializeField]
        private TargetType targetType = default;

        [SerializeField]
        private AddType addType = default;

        [SerializeField]
        private float value = default;

        public IObservable<Unit> Invoke(BattleSystem battleManager, BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                var character = targetType == TargetType.Myself ? attacker : target;
                character.CurrentSpec.Status.AddPower(value, powerType, addType);
                var resultPower = character.CurrentSpec.Status.GetPower(powerType).Value.ToString("0.00");
                battleManager.AddLog(ScriptLocalization.UI.Sentence_AddPower.Format(character.CurrentSpec.Name, powerType.AsLocalize(), resultPower));

                return Observable.Timer(TimeSpan.FromSeconds(1.0f)).AsUnitObservable();
            });
        }
    }
}
