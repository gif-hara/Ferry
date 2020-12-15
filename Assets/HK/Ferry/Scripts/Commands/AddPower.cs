using System;
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

        public IObservable<Unit> Invoke(BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                attacker.CurrentSpec.Status.AddPower(value, powerType);
                return Observable.ReturnUnit();
            });
        }
    }
}
