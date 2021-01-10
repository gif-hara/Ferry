﻿using System;
using System.Collections.Generic;
using System.Linq;
using HK.Ferry.BattleSystems.Skills;
using HK.Ferry.Database;
using UniRx;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CharacterStatus
    {
        public IntReactiveProperty hitPoint;

        public IntReactiveProperty attack;

        public IntReactiveProperty defense;

        public IntReactiveProperty evasion;

        public IntReactiveProperty critical;

        public CharacterStatus(int hitPoint, int attack, int defense, int evasion, int critical)
        {
            this.hitPoint = new IntReactiveProperty(hitPoint);
            this.attack = new IntReactiveProperty(attack);
            this.defense = new IntReactiveProperty(defense);
            this.evasion = new IntReactiveProperty(evasion);
            this.critical = new IntReactiveProperty(critical);
        }

        public CharacterStatus(CharacterStatus other)
            : this(
                  other.hitPoint.Value,
                  other.attack.Value,
                  other.defense.Value,
                  other.evasion.Value,
                  other.critical.Value
                 )
        {
        }

        public void Set(CharacterStatus other)
        {
            this.hitPoint.Value = other.hitPoint.Value;
            this.attack.Value = other.attack.Value;
            this.defense.Value = other.defense.Value;
            this.evasion.Value = other.evasion.Value;
            this.critical.Value = other.critical.Value;
        }

        /// <summary>
        /// 装備品のステータスを加算する
        /// </summary>
        public void Add(MasterDataEquipment.Record equipment)
        {
            this.hitPoint.Value += equipment.HitPoint;
            this.attack.Value += equipment.Attack;
            this.defense.Value += equipment.Defense;
            this.evasion.Value += equipment.Evasion;
            this.critical.Value += equipment.Critical;
        }

        /// <summary>
        /// スキルからステータスを加算する
        /// </summary>
        public void Add(List<ISkill> skills)
        {
            foreach (var s in skills.OfType<IStatusUp>())
            {
                Get(s.StatusType).Value += s.GetAddValue();
            }
        }

        public IntReactiveProperty Get(StatusType statusType)
        {
            switch (statusType)
            {
                case StatusType.HitPoint:
                    return hitPoint;
                case StatusType.Attack:
                    return attack;
                case StatusType.Defense:
                    return defense;
                case StatusType.Evasion:
                    return evasion;
                case StatusType.Critical:
                    return critical;
                default:
                    Assert.IsTrue(false, $"{statusType}は未対応です");
                    return null;
            }
        }
    }
}
