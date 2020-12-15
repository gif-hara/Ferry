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
        private float value = default;

        public IObservable<Unit> Invoke(BattleManager battleManager, BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                attacker.CurrentSpec.Status.AddPower(value, powerType);
                battleManager.AddLog(ScriptLocalization.UI.Sentence_AddPower.Format(attacker.CurrentSpec.Name, powerType.AsLocalize(), value));
                return Observable.ReturnUnit();
            });
        }
    }
}
