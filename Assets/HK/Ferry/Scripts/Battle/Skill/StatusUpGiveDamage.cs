using System;
using UniRx;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// ダメージを与えた際にステータスを上昇させる<see cref="ISkill"/>
    /// </summary>
    public sealed class StatusUpGiveDamage : Skill, IOnGiveDamage
    {
        private readonly StatusType statusType;

        public StatusUpGiveDamage(int level, StatusType statusType) : base(level)
        {
            this.statusType = statusType;
        }

        public IObservable<Unit> OnGiveDamage(BattleCharacter attacker, BattleCharacter target)
        {
            return Observable.Defer(() =>
            {
                attacker.AddStatus(statusType, BattleCalcurator.GetStatusUpGiveDamageAddValue(statusType, Level));

                return Observable.ReturnUnit();
            });
        }
    }
}
