using System;
using HK.Ferry.Extensions;
using I2.Loc;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AbnormalStateElementPoison : AbnormalStateElement
    {
        public AbnormalStateElementPoison(int remainingTurn, AbnormalStateType abnormalStateType, BattleCharacter owner, BattleSystem battleSystem)
            : base(remainingTurn, abnormalStateType, owner, battleSystem)
        {
        }

        protected override IObservable<Unit> OnEndTurnInternal()
        {
            var damage = BattleCalcurator.GetDamageFromPoison(Owner);
            Owner.TakeDamageRaw(damage);
            BattleSystem.AddLog(ScriptLocalization.UI.Sentence_DamageFromPoison.Format(Owner.CurrentSpec.Name, damage));

            return Observable.Timer(TimeSpan.FromSeconds(1.0f)).AsUnitObservable();
        }
    }
}
