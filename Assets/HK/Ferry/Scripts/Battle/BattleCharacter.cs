﻿using System.Collections.Generic;
using System.Linq;
using HK.Ferry.BattleSystems;
using HK.Ferry.BattleSystems.Skills;
using UnityEngine;
using UnityEngine.Assertions;

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

        public BattleCharacter(CharacterSpec characterSpec)
        {
            CurrentSpec = new CharacterSpec(characterSpec);
            BaseSpec = characterSpec;
            Skills = CurrentSpec.SkillTypes
                .GroupBy(x => x)
                .Select(x => SkillFactory.Create(x.Key, x.Count()))
                .ToList();
        }

        public float HitPointRate => (float)CurrentSpec.Status.hitPoint.Value / BaseSpec.Status.hitPoint.Value;

        public virtual void StartTurn()
        {
        }

        /// <summary>
        /// 通常攻撃で<paramref name="target"/>にダメージを与える
        /// </summary>
        public int GiveDamage(BattleCharacter target)
        {
            var damage = BattleCalcurator.GetDamage(CurrentSpec.Status, target.CurrentSpec.Status, 1.0f);
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
