using System;
using System.Collections.Generic;
using System.Linq;
using HK.Ferry.BattleSystems;
using HK.Ferry.BattleSystems.Skills;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BattleCharacter
    {
        public CharacterSpec CurrentSpec
        {
            get;
            private set;
        }

        public CharacterSpec BaseSpec
        {
            get;
            private set;
        }

        public List<ISkill> Skills
        {
            get;
            private set;
        }

        public readonly AbnormalStateController AbnormalStateController;

        public BattleCharacter(BattleSystem battleSystem, CharacterSpec characterSpec, List<ISkill> skills)
        {
            CurrentSpec = new CharacterSpec(characterSpec);
            BaseSpec = characterSpec;
            Skills = skills;
            AbnormalStateController = new AbnormalStateController(this, battleSystem);
        }

        public float HitPointRate => (float)CurrentSpec.Status.hitPoint.Value / BaseSpec.Status.hitPoint.Value;

        public virtual IObservable<Unit> StartBattle()
        {
            return Observable.Defer(() =>
            {
                return Observable.Concat(
                    Skills.OfType<IOnStartBattle>()
                        .Select(x => x.OnStartBattle())
                )
                .AsSingleUnitObservable();
            });
        }

        /// <summary>
        /// ターン開始時の処理
        /// </summary>
        public virtual void StartTurn()
        {
        }

        /// <summary>
        /// ターン終了時の処理
        /// </summary>
        public virtual IObservable<Unit> EndTurn()
        {
            return AbnormalStateController.EndTurn();
        }

        /// <summary>
        /// 通常攻撃で<paramref name="target"/>にダメージを与える
        /// </summary>
        public int GiveDamage(BattleCharacter target)
        {
            var damage = BattleCalcurator.GetDamage(this, target, CurrentSpec.AttackAttribute, 1.0f);
            target.TakeDamage(this, damage);

            return damage;
        }

        /// <summary>
        /// 通常攻撃でダメージを受ける
        /// </summary>
        /// <param name="value"></param>
        public void TakeDamage(BattleCharacter attacker, int value)
        {
            TakeDamageRaw(value);
        }

        /// <summary>
        /// 実際にダメージを受けた際の処理
        /// </summary>
        public void TakeDamageRaw(int value)
        {
            CurrentSpec.Status.hitPoint.Value -= value;
        }

        public bool IsDead => CurrentSpec.Status.hitPoint.Value <= 0;

        public void AddStatus(StatusType statusType, int value)
        {
            CurrentSpec.Status.Add(statusType, value);
        }
    }
}
