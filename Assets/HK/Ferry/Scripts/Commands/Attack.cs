using System;
using HK.Ferry.BattleSystems;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class Attack : ICommand
    {
        [SerializeField]
        private float rate = 1.0f;

        public IObservable<Unit> Invoke(BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                var damage = BattleCalcurator.GetDamage(attacker.CurrentSpec.Status, target.CurrentSpec.Status, rate);
                target.CurrentSpec.Status.hitPoint.Value -= damage;
                Debug.Log($"damage = {damage}, TODO Attack Effect");

                return Observable.Timer(TimeSpan.FromSeconds(1.0f)).AsUnitObservable();
            });
        }
    }
}
