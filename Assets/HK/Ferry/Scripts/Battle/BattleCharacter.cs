using System;
using System.Collections.Generic;
using System.Linq;
using HK.Ferry.BattleSystems;
using HK.Ferry.BattleSystems.Skills;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;

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

        public BattleCharacter(CharacterSpec characterSpec, List<ISkill> skills)
        {
            CurrentSpec = new CharacterSpec(characterSpec);
            BaseSpec = characterSpec;
            Skills = skills;
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
        /// 通常攻撃で<paramref name="target"/>にダメージを与える
        /// </summary>
        public int GiveDamage(BattleCharacter target)
        {
            var damage = BattleCalcurator.GetDamage(this, target);
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
    }
}
