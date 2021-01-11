﻿using System;
using I2.Loc;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;
using HK.Ferry.Extensions;

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

        public IObservable<Unit> OnTakeDamage(BattleSystem battleSystem, BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                var battleCharacter = BattleUtility.GetBattleCharacter(attacker, target, targetType);
                var rate = BattleCalcurator.GetAbnormalStateAddRate(abnormalStateType, Level);
                if (battleCharacter.AbnormalStateController.Lottery(abnormalStateType, rate) && battleCharacter.AbnormalStateController.Add(abnormalStateType))
                {
                    battleSystem.AddLog(ScriptLocalization.UI.Sentence_AddedAbnormalState.Format(battleCharacter.CurrentSpec.Name, abnormalStateType));
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
