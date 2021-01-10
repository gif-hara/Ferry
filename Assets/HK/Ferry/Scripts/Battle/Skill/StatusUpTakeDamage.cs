using System;
using UniRx;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// ダメージを受けた際にステータスを上昇させる<see cref="ISkill"/>
    /// </summary>
    public sealed class StatusUpTakeDamage : Skill, IOnTakeDamage
    {
        private readonly StatusType statusType;

        public StatusUpTakeDamage(int level, StatusType statusType) : base(level)
        {
            this.statusType = statusType;
        }

        public IObservable<Unit> OnTakeDamage(BattleSystem battleSystem, BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                target.AddStatus(statusType, BattleCalcurator.GetStatusUpTakeDamageAddValue(statusType, Level));

                return Observable.ReturnUnit();
            });
        }
    }
}
