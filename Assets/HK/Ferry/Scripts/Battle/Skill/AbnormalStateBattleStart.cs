using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// バトル開始時に自分に状態異常を付与する<see cref="ISkill"/>
    /// </summary>
    public sealed class AbnormalStateBattleStart : Skill, IOnStartBattle
    {
        private AbnormalStateType abnormalStateType;

        public AbnormalStateBattleStart(int level, AbnormalStateType abnormalStateType) : base(level)
        {
            this.abnormalStateType = abnormalStateType;
        }

        public IObservable<Unit> OnStartBattle()
        {
            return Observable.Defer(() =>
            {
                Debug.Log($"TODO: バトル開始時に{abnormalStateType}付与");

                return Observable.ReturnUnit();
            });
        }
    }
}
