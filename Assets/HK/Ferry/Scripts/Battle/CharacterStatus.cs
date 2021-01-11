using System;
using System.Collections.Generic;
using System.Linq;
using HK.Ferry.BattleSystems;
using HK.Ferry.BattleSystems.Skills;
using HK.Ferry.Database;
using HK.Ferry.Extensions;
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
    [Serializable]
    public class CharacterStatus
    {
        public IntReactiveProperty hitPoint;

        public IntReactiveProperty attack;

        public IntReactiveProperty defense;

        public IntReactiveProperty evasion;

        public IntReactiveProperty critical;

        public AbnormalStateResistance abnormalStateResistance;

        public CharacterStatus(int hitPoint, int attack, int defense, int evasion, int critical, AbnormalStateResistance abnormalStateResistance)
        {
            this.hitPoint = new IntReactiveProperty(hitPoint);
            this.attack = new IntReactiveProperty(attack);
            this.defense = new IntReactiveProperty(defense);
            this.evasion = new IntReactiveProperty(evasion);
            this.critical = new IntReactiveProperty(critical);
            this.abnormalStateResistance = abnormalStateResistance;
        }

        public CharacterStatus(CharacterStatus other)
            : this(
                  other.hitPoint.Value,
                  other.attack.Value,
                  other.defense.Value,
                  other.evasion.Value,
                  other.critical.Value,
                  new AbnormalStateResistance(other.abnormalStateResistance)
                 )
        {
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
        public void Add(List<ISkill> skills, CharacterStatus baseStatus)
        {
            foreach (var s in skills.OfType<IStatusUp>())
            {
                Get(s.StatusType).Value += s.GetAddValue();
            }

            var fightingLevel = skills.GetSkillLevel(SkillType.Fighting);
            if (fightingLevel > 0)
            {
                Add(StatusType.HitPoint, -Get(StatusType.HitPoint).Value / 2);
                Add(StatusType.Attack, Mathf.FloorToInt(baseStatus.Get(StatusType.Attack).Value * BattleCalcurator.GetFightingAddRate(fightingLevel)));
            }

            var samuraiTechniqueLevel = skills.GetSkillLevel(SkillType.SamuraiTechnique);
            if (samuraiTechniqueLevel > 0)
            {
                Add(StatusType.Defense, -Get(StatusType.Defense).Value / 2);
                Add(StatusType.Attack, Mathf.FloorToInt(baseStatus.Get(StatusType.Attack).Value * BattleCalcurator.GetSamuraiTechniqueAddRate(samuraiTechniqueLevel)));
            }

            var shinobiTechniqueLevel = skills.GetSkillLevel(SkillType.SamuraiTechnique);
            if (shinobiTechniqueLevel > 0)
            {
                Add(StatusType.Defense, -Get(StatusType.Defense).Value / 2);
                Add(StatusType.Evasion, Mathf.FloorToInt(baseStatus.Get(StatusType.Evasion).Value * BattleCalcurator.GetShinobiTechniqueAddRate(shinobiTechniqueLevel)));
            }

            var motionLessLevel = skills.GetSkillLevel(SkillType.Motionless);
            if (motionLessLevel > 0)
            {
                Add(StatusType.Evasion, -Get(StatusType.Evasion).Value);
                Add(StatusType.Attack, Mathf.FloorToInt(baseStatus.Get(StatusType.Attack).Value * BattleCalcurator.GetMotionLessAddRate(motionLessLevel)));
            }
        }

        public void Add(StatusType statusType, int value)
        {
            Get(statusType).Value += value;
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
