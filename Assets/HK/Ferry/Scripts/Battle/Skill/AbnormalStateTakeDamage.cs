using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// ダメージを受ける際に状態異常を付与する<see cref="ISkill"/>
    /// </summary>
    public sealed class AbnormalStateTakeDamage : Skill, IOnTakeDamage
    {
        private AbnormalStateType abnormalStateType;

        private TargetType targetType;

        public AbnormalStateTakeDamage(int level, AbnormalStateType abnormalStateType, TargetType targetType) : base(level)
        {
            this.abnormalStateType = abnormalStateType;
            this.targetType = targetType;
        }

        public IObservable<Unit> OnTakeDamage(BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                Debug.Log($"TODO {nameof(AbnormalStateTakeDamage)} {abnormalStateType}, {targetType}");
                return Observable.ReturnUnit();
            });
        }
    }
}
