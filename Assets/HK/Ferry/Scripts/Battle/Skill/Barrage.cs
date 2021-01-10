using System;
using I2.Loc;
using UniRx;
using HK.Ferry.Extensions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// ダメージを受けた際にステータスを上昇させる<see cref="ISkill"/>
    /// </summary>
    public sealed class Barrage : Skill, IOnGiveDamage
    {
        private readonly AttackAttribute attackAttribute;

        public Barrage(int level, AttackAttribute attackAttribute) : base(level)
        {
            this.attackAttribute = attackAttribute;
        }

        public IObservable<Unit> OnGiveDamage(BattleSystem battleSystem, BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                var damage = BattleCalcurator.GetDamage(attacker, target, attackAttribute, BattleCalcurator.GetBarrageDamageRate(Level));
                target.TakeDamageRaw(damage);
                battleSystem.AddLog(ScriptLocalization.UI.Sentence_Attack.Format(attacker.CurrentSpec.Name, target.CurrentSpec.Name, damage));

                return Observable.Timer(TimeSpan.FromSeconds(1.0f)).AsUnitObservable();
            });
        }
    }
}
