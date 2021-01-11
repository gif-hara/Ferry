using System;
using UniRx;
using UnityEngine;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// 状態異常の耐性を上昇させる<see cref="ISkill"/>
    /// </summary>
    public sealed class AbnormalStateDisable : Skill, IOnStartBattle
    {
        private AbnormalStateType abnormalStateType;

        public AbnormalStateDisable(int level, AbnormalStateType abnormalStateType) : base(level)
        {
            this.abnormalStateType = abnormalStateType;
        }

        public IObservable<Unit> OnStartBattle(BattleCharacter owner)
        {
            return Observable.Defer(() =>
            {
                owner.CurrentSpec.Status.abnormalStateResistance.Set(abnormalStateType, BattleCalcurator.GetAbnormalStateResistanceFromSkill(Level));
                return Observable.ReturnUnit();
            });
        }
    }
}
