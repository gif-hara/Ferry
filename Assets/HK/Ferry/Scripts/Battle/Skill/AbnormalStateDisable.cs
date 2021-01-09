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

        public IObservable<Unit> OnStartBattle()
        {
            return Observable.Defer(() =>
            {
                Debug.Log($"TODO: バトル開始時に{abnormalStateType}の耐性を上げる");
                return Observable.ReturnUnit();
            });
        }
    }
}
