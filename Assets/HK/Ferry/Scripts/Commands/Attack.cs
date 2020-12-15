using System;
using HK.Ferry.BattleSystems;
using HK.Ferry.Extensions;
using I2.Loc;
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

        public IObservable<Unit> Invoke(BattleManager battleManager, BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                var damage = BattleCalcurator.GetDamage(attacker.CurrentSpec.Status, target.CurrentSpec.Status, rate);
                target.TakeDamage(damage);
                battleManager.AddLog(ScriptLocalization.UI.Sentence_Attack.Format(attacker.CurrentSpec.Name, target.CurrentSpec.Name, damage));

                return Observable.ReturnUnit();
            });
        }
    }
}
