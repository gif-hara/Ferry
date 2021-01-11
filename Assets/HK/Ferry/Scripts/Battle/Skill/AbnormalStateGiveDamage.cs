using System;
using HK.Ferry.Extensions;
using I2.Loc;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// ダメージを与えた際に状態異常を付与する<see cref="ISkill"/>
    /// </summary>
    public sealed class AbnormalStateGiveDamage : Skill, IOnGiveDamage
    {
        private AbnormalStateType abnormalStateType;

        private TargetType targetType;

        public AbnormalStateGiveDamage(int level, AbnormalStateType abnormalStateType, TargetType targetType) : base(level)
        {
            this.abnormalStateType = abnormalStateType;
            this.targetType = targetType;
        }

        public IObservable<Unit> OnGiveDamage(BattleSystem battleSystem, BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                var battleCharacter = BattleUtility.GetBattleCharacter(attacker, target, targetType);
                if (battleCharacter.AbnormalStateController.Add(abnormalStateType))
                {
                    battleSystem.AddLog(ScriptLocalization.UI.AddedAbnormalState.Format(battleCharacter.CurrentSpec.Name, abnormalStateType));
                    return Observable.Timer(TimeSpan.FromSeconds(1.0f)).AsUnitObservable();
                }
                else
                {
                    return Observable.ReturnUnit();
                }
            });
        }
    }
}
