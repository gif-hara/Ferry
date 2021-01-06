using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// ターゲットタイプ
        /// </summary>
        public enum TargetType
        {
            /// <summary>
            /// 自分自身
            /// </summary>
            Myself,

            /// <summary>
            /// 相手
            /// </summary>
            Opponent,
        }

        /// <summary>
        /// 加算タイプ
        /// </summary>
        public enum AddType
        {
            /// <summary>
            /// 固定加算
            /// </summary>
            Fixed,

            /// <summary>
            /// 割合加算
            /// </summary>
            Percentage,

            /// <summary>
            /// 代入
            /// </summary>
            Set
        }

        public enum CompareType
        {
            /// <summary>
            /// a > b
            /// </summary>
            Greater,

            /// <summary>
            /// a >= b
            /// </summary>
            GreaterEqual,

            /// <summary>
            /// a < b
            /// </summary>
            Lesser,

            /// <summary>
            /// a <= b
            /// </summary>
            LesserEqual,

            /// <summary>
            /// a == b
            /// </summary>
            Equal,
        }

        /// <summary>
        /// 識別タイプ
        /// </summary>
        public enum IdentifyType
        {
            /// <summary>
            /// 未識別
            /// </summary>
            Unidentify,

            /// <summary>
            /// 識別可能
            /// </summary>
            IdentifyPosible,

            /// <summary>
            /// 識別
            /// </summary>
            Identify,
        }

        [Flags]
        public enum DirectionType
        {
            LeftTop = 1,
            Top = 1 << 1,
            RightTop = 1 << 2,
            Right = 1 << 3,
            RightBottom = 1 << 4,
            Bottom = 1 << 5,
            LeftBottom = 1 << 6,
            Left = 1 << 7
        }

        /// <summary>
        /// 攻撃属性
        /// </summary>
        public enum AttackAttribute
        {
            /// <summary>
            /// 斬撃
            /// </summary>
            Slash,

            /// <summary>
            /// 刺突
            /// </summary>
            Spear,

            /// <summary>
            /// 打撃
            /// </summary>
            Blow,

            /// <summary>
            /// 魔法
            /// </summary>
            Magic,
        }

        /// <summary>
        /// ステータスタイプ
        /// </summary>
        public enum StatusType
        {
            HitPoint,
            Attack,
            Defense,
            Evasion,
            Critical,
        }

        /// <summary>
        /// 状態異常タイプ
        /// </summary>
        public enum AbnormalStateType
        {
            /// <summary>
            /// 毒
            /// ターン終了時にダメージを受ける
            /// </summary>
            Poison,

            /// <summary>
            /// 麻痺
            /// 時々行動出来ない
            /// </summary>
            Paralysis,

            /// <summary>
            /// 混乱
            /// 時々自分に攻撃してしまう
            /// </summary>
            Confusion,

            /// <summary>
            /// 目潰し
            /// 時々攻撃が当たらない
            /// </summary>
            BlindEyes,

            /// <summary>
            /// 怯み
            /// 必ず動けない
            /// </summary>
            Flinch,

            /// <summary>
            /// 急所
            /// 被ダメ計算時に会心率が上昇する
            /// </summary>
            Vitals,

            /// <summary>
            /// 影縫
            /// 回避出来なくなる
            /// </summary>
            Quilting,

            /// <summary>
            /// 疲労
            /// 攻撃力が半分になる
            /// </summary>
            Tiredness,

            /// <summary>
            /// 封印
            /// 全てのスキルを無効化
            /// </summary>
            Seal,

            /// <summary>
            /// 治癒
            /// ターン終了時に回復する
            /// </summary>
            Healing,

            /// <summary>
            /// 心眼
            /// 必ず会心ダメージ
            /// </summary>
            MindEyes,

            /// <summary>
            /// 吸収
            /// 与ダメを吸収する
            /// </summary>
            Absorption,

            /// <summary>
            /// 俊足
            /// 2回行動
            /// </summary>
            FastRunner,

            /// <summary>
            /// 反撃
            /// 受けたダメージを返す
            /// </summary>
            CounterAttack,
        }

        public enum SkillType
        {
            /// <summary>
            /// 毒無効
            /// </summary>
            AbnormalStateDisable_Poison = 10000,

            /// <summary>
            /// 麻痺無効
            /// </summary>
            AbnormalStateDisable_Paralysis,

            /// <summary>
            /// 混乱無効
            /// </summary>
            AbnormalStateDisable_Confusion,

            /// <summary>
            /// 目潰し無効
            /// </summary>
            AbnormalStateDisable_BlindEyes,

            /// <summary>
            /// 怯み無効
            /// </summary>
            AbnormalStateDisable_Flinch,

            /// <summary>
            /// 急所無効
            /// </summary>
            AbnormalStateDisable_Vitals,

            /// <summary>
            /// 影縫無効
            /// </summary>
            AbnormalStateDisable_Quilting,

            /// <summary>
            /// 疲労無効
            /// </summary>
            AbnormalStateDisable_Tiredness,

            /// <summary>
            /// 封印無効
            /// </summary>
            AbnormalStateDisable_Seal,

            /// <summary>
            /// 治癒無効
            /// </summary>
            AbnormalStateDisable_Healing,

            /// <summary>
            /// 心眼無効
            /// </summary>
            AbnormalStateDisable_MindEyes,

            /// <summary>
            /// 吸収無効
            /// </summary>
            AbnormalStateDisable_Absorption,

            /// <summary>
            /// 俊足無効
            /// </summary>
            AbnormalStateDisable_FastRunner,

            /// <summary>
            /// 反撃無効
            /// </summary>
            AbnormalStateDisable_CounterAttack,

            /// <summary>
            /// ずっと毒付与
            /// </summary>
            AbnormalStateAllTheWay_Poison = 10100,

            /// <summary>
            /// ずっと麻痺付与
            /// </summary>
            AbnormalStateAllTheWay_Paralysis,

            /// <summary>
            /// ずっと混乱付与
            /// </summary>
            AbnormalStateAllTheWay_Confusion,

            /// <summary>
            /// ずっと目潰し付与
            /// </summary>
            AbnormalStateAllTheWay_BlindEyes,

            /// <summary>
            /// ずっと怯み付与
            /// </summary>
            AbnormalStateAllTheWay_Flinch,

            /// <summary>
            /// ずっと急所付与
            /// </summary>
            AbnormalStateAllTheWay_Vitals,

            /// <summary>
            /// ずっと影縫付与
            /// </summary>
            AbnormalStateAllTheWay_Quilting,

            /// <summary>
            /// ずっと疲労付与
            /// </summary>
            AbnormalStateAllTheWay_Tiredness,

            /// <summary>
            /// ずっと封印付与
            /// </summary>
            AbnormalStateAllTheWay_Seal,

            /// <summary>
            /// ずっと治癒付与
            /// </summary>
            AbnormalStateAllTheWay_Healing,

            /// <summary>
            /// ずっと心眼付与
            /// </summary>
            AbnormalStateAllTheWay_MindEyes,

            /// <summary>
            /// ずっと吸収付与
            /// </summary>
            AbnormalStateAllTheWay_Absorption,

            /// <summary>
            /// ずっと俊足付与
            /// </summary>
            AbnormalStateAllTheWay_FastRunner,

            /// <summary>
            /// ずっと反撃付与
            /// </summary>
            AbnormalStateAllTheWay_CounterAttack,

            /// <summary>
            /// バトル開始時に毒付与
            /// </summary>
            AbnormalStateBattleStart_Poison = 10200,

            /// <summary>
            /// バトル開始時に麻痺付与
            /// </summary>
            AbnormalStateBattleStart_Paralysis,

            /// <summary>
            /// バトル開始時に混乱付与
            /// </summary>
            AbnormalStateBattleStart_Confusion,

            /// <summary>
            /// バトル開始時に目潰し付与
            /// </summary>
            AbnormalStateBattleStart_BlindEyes,

            /// <summary>
            /// バトル開始時に怯み付与
            /// </summary>
            AbnormalStateBattleStart_Flinch,

            /// <summary>
            /// バトル開始時に急所付与
            /// </summary>
            AbnormalStateBattleStart_Vitals,

            /// <summary>
            /// バトル開始時に影縫付与
            /// </summary>
            AbnormalStateBattleStart_Quilting,

            /// <summary>
            /// バトル開始時に疲労付与
            /// </summary>
            AbnormalStateBattleStart_Tiredness,

            /// <summary>
            /// バトル開始時に封印付与
            /// </summary>
            AbnormalStateBattleStart_Seal,

            /// <summary>
            /// バトル開始時に治癒付与
            /// </summary>
            AbnormalStateBattleStart_Healing,

            /// <summary>
            /// バトル開始時に心眼付与
            /// </summary>
            AbnormalStateBattleStart_MindEyes,

            /// <summary>
            /// バトル開始時に吸収付与
            /// </summary>
            AbnormalStateBattleStart_Absorption,

            /// <summary>
            /// バトル開始時に俊足付与
            /// </summary>
            AbnormalStateBattleStart_FastRunner,

            /// <summary>
            /// バトル開始時に反撃付与
            /// </summary>
            AbnormalStateBattleStart_CounterAttack,

            /// <summary>
            /// 与ダメ時に自分に毒付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Poison = 10300,

            /// <summary>
            /// 与ダメ時に自分に麻痺付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Paralysis,

            /// <summary>
            /// 与ダメ時に自分に混乱付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Confusion,

            /// <summary>
            /// 与ダメ時に自分に目潰し付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_BlindEyes,

            /// <summary>
            /// 与ダメ時に自分に怯み付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Flinch,

            /// <summary>
            /// 与ダメ時に自分に急所付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Vitals,

            /// <summary>
            /// 与ダメ時に自分に影縫付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Quilting,

            /// <summary>
            /// 与ダメ時に自分に疲労付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Tiredness,

            /// <summary>
            /// 与ダメ時に自分に封印付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Seal,

            /// <summary>
            /// 与ダメ時に自分に治癒付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Healing,

            /// <summary>
            /// 与ダメ時に自分に心眼付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_MindEyes,

            /// <summary>
            /// 与ダメ時に自分に吸収付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_Absorption,

            /// <summary>
            /// 与ダメ時に自分に俊足付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_FastRunner,

            /// <summary>
            /// 与ダメ時に自分に反撃付与
            /// </summary>
            AbnormalStateGiveDamageMySelf_CounterAttack,

            /// <summary>
            /// 与ダメ時に相手に毒付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Poison = 10400,

            /// <summary>
            /// 与ダメ時に相手に麻痺付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Paralysis,

            /// <summary>
            /// 与ダメ時に相手に混乱付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Confusion,

            /// <summary>
            /// 与ダメ時に相手に目潰し付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_BlindEyes,

            /// <summary>
            /// 与ダメ時に相手に怯み付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Flinch,

            /// <summary>
            /// 与ダメ時に相手に急所付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Vitals,

            /// <summary>
            /// 与ダメ時に相手に影縫付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Quilting,

            /// <summary>
            /// 与ダメ時に相手に疲労付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Tiredness,

            /// <summary>
            /// 与ダメ時に相手に封印付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Seal,

            /// <summary>
            /// 与ダメ時に相手に治癒付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Healing,

            /// <summary>
            /// 与ダメ時に相手に心眼付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_MindEyes,

            /// <summary>
            /// 与ダメ時に相手に吸収付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_Absorption,

            /// <summary>
            /// 与ダメ時に相手に俊足付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_FastRunner,

            /// <summary>
            /// 与ダメ時に相手に反撃付与
            /// </summary>
            AbnormalStateGiveDamageOpponent_CounterAttack,

            /// <summary>
            /// 被ダメ時に自分に毒付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Poison = 10500,

            /// <summary>
            /// 被ダメ時に自分に麻痺付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Paralysis,

            /// <summary>
            /// 被ダメ時に自分に混乱付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Confusion,

            /// <summary>
            /// 被ダメ時に自分に目潰し付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_BlindEyes,

            /// <summary>
            /// 被ダメ時に自分に怯み付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Flinch,

            /// <summary>
            /// 被ダメ時に自分に急所付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Vitals,

            /// <summary>
            /// 被ダメ時に自分に影縫付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Quilting,

            /// <summary>
            /// 被ダメ時に自分に疲労付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Tiredness,

            /// <summary>
            /// 被ダメ時に自分に封印付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Seal,

            /// <summary>
            /// 被ダメ時に自分に治癒付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Healing,

            /// <summary>
            /// 被ダメ時に自分に心眼付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_MindEyes,

            /// <summary>
            /// 被ダメ時に自分に吸収付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_Absorption,

            /// <summary>
            /// 被ダメ時に自分に俊足付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_FastRunner,

            /// <summary>
            /// 被ダメ時に自分に反撃付与
            /// </summary>
            AbnormalStateTakeDamageMySelf_CounterAttack,

            /// <summary>
            /// 被ダメ時に相手に毒付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Poison = 10600,

            /// <summary>
            /// 被ダメ時に相手に麻痺付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Paralysis,

            /// <summary>
            /// 被ダメ時に相手に混乱付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Confusion,

            /// <summary>
            /// 被ダメ時に相手に目潰し付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_BlindEyes,

            /// <summary>
            /// 被ダメ時に相手に怯み付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Flinch,

            /// <summary>
            /// 被ダメ時に相手に急所付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Vitals,

            /// <summary>
            /// 被ダメ時に相手に影縫付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Quilting,

            /// <summary>
            /// 被ダメ時に相手に疲労付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Tiredness,

            /// <summary>
            /// 被ダメ時に相手に封印付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Seal,

            /// <summary>
            /// 被ダメ時に相手に治癒付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Healing,

            /// <summary>
            /// 被ダメ時に相手に心眼付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_MindEyes,

            /// <summary>
            /// 被ダメ時に相手に吸収付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_Absorption,

            /// <summary>
            /// 被ダメ時に相手に俊足付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_FastRunner,

            /// <summary>
            /// 被ダメ時に相手に反撃付与
            /// </summary>
            AbnormalStateTakeDamageOpponent_CounterAttack,

            /// <summary>
            /// 斬撃属性のダメージ軽減
            /// </summary>
            AttackAttributeResistance_Slash = 10700,

            /// <summary>
            /// 刺突属性のダメージ軽減
            /// </summary>
            AttackAttributeResistance_Spear,

            /// <summary>
            /// 打撃属性のダメージ軽減
            /// </summary>
            AttackAttributeResistance_Blow,

            /// <summary>
            /// 魔法属性のダメージ軽減
            /// </summary>
            AttackAttributeResistance_Magic,

            /// <summary>
            /// 斬撃属性のダメージ無効
            /// </summary>
            AttackAttributeDisable_Slash = 10800,

            /// <summary>
            /// 刺突属性のダメージ無効
            /// </summary>
            AttackAttributeDisable_Spear,

            /// <summary>
            /// 打撃属性のダメージ無効
            /// </summary>
            AttackAttributeDisable_Blow,

            /// <summary>
            /// 魔法属性のダメージ無効
            /// </summary>
            AttackAttributeDisable_Magic,

            /// <summary>
            /// 体力上昇
            /// </summary>
            StatusUp_HitPoint = 10900,

            /// <summary>
            /// 攻撃力上昇
            /// </summary>
            StatusUp_Attack,

            /// <summary>
            /// 防御力上昇
            /// </summary>
            StatusUp_Defense,

            /// <summary>
            /// 回避率上昇
            /// </summary>
            StatusUp_Evasion,

            /// <summary>
            /// 会心率上昇
            /// </summary>
            StatusUp_Critical,

            /// <summary>
            /// 与ダメで体力上昇
            /// </summary>
            Sadism_HitPoint = 11000,

            /// <summary>
            /// 与ダメで攻撃力上昇
            /// </summary>
            Sadism_Attack,

            /// <summary>
            /// 与ダメで防御力上昇
            /// </summary>
            Sadism_Defense,

            /// <summary>
            /// 与ダメで回避率上昇
            /// </summary>
            Sadism_Evasion,

            /// <summary>
            /// 与ダメで会心率上昇
            /// </summary>
            Sadism_Critical,

            /// <summary>
            /// 被ダメで体力上昇
            /// </summary>
            Masochism_HitPoint = 11100,

            /// <summary>
            /// 被ダメで攻撃力上昇
            /// </summary>
            Masochism_Attack,

            /// <summary>
            /// 被ダメで防御力上昇
            /// </summary>
            Masochism_Defense,

            /// <summary>
            /// 被ダメで回避率上昇
            /// </summary>
            Masochism_Evasion,

            /// <summary>
            /// 被ダメで会心率上昇
            /// </summary>
            Masochism_Critical,

            /// <summary>
            /// 通常攻撃に斬撃の追加ダメージ
            /// </summary>
            Barrage_Slash = 11200,

            /// <summary>
            /// 通常攻撃に刺突の追加ダメージ
            /// </summary>
            Barrage_Spear,

            /// <summary>
            /// 通常攻撃に打撃の追加ダメージ
            /// </summary>
            Barrage_Blow,

            /// <summary>
            /// 通常攻撃に魔法の追加ダメージ
            /// </summary>
            Barrage_Magic,

            /// <summary>
            /// デバフ系状態異常が付与されている場合に体力上昇
            /// </summary>
            StatusUp_OnDebuff_HitPoint = 11300,

            /// <summary>
            /// デバフ系状態異常が付与されている場合に攻撃力上昇
            /// </summary>
            StatusUp_OnDebuff_Attack,

            /// <summary>
            /// デバフ系状態異常が付与されている場合に防御力上昇
            /// </summary>
            StatusUp_OnDebuff_Defense,

            /// <summary>
            /// デバフ系状態異常が付与されている場合に回避率上昇
            /// </summary>
            StatusUp_OnDebuff_Evasion,

            /// <summary>
            /// デバフ系状態異常が付与されている場合に会心率上昇
            /// </summary>
            StatusUp_OnDebuff_Critical,

            /// <summary>
            /// 会心時のダメージが増加する
            /// </summary>
            SuperCritical = 11400,

            /// <summary>
            /// 死亡した際に1度だけHP1で復活する
            /// </summary>
            Spirit,

            /// <summary>
            /// 回避率が0になる代わりに攻撃力が上昇する
            /// </summary>
            Motionless,

            /// <summary>
            /// 体力が半分になる代わりに攻撃力が上昇する
            /// </summary>
            Fighting,

            /// <summary>
            /// 防御力が半分になる代わりに攻撃力が上昇する
            /// </summary>
            SamuraiTechnique,

            /// <summary>
            /// 防御力が半分になる代わりに回避率が上昇する
            /// </summary>
            ShinobiTechnique,

            /// <summary>
            /// アイテムドロップ率上昇
            /// </summary>
            ItemDropUp,
        }
    }
}
