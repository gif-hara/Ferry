using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// バトル開始時に自分に状態異常を付与する<see cref="ISkill"/>
    /// </summary>
    public sealed class AbnormalStateBattleStart : Skill, IOnStartBattle
    {
        private AbnormalStateType abnormalStateType;

        /// <summary>
        /// ずっと付与するか
        /// </summary>
        private bool isAllTheWay;

        public AbnormalStateBattleStart(int level, AbnormalStateType abnormalStateType, bool isAllTheWay) : base(level)
        {
            this.abnormalStateType = abnormalStateType;
            this.isAllTheWay = isAllTheWay;
        }

        public IObservable<Unit> OnStartBattle(BattleCharacter owner)
        {
            return Observable.Defer(() =>
            {
                owner.AbnormalStateController.Add(abnormalStateType, isAllTheWay);

                return Observable.ReturnUnit();
            });
        }
    }
}
