using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public class AbnormalStateElement : IAbnormalStateElement
    {
        public int RemainingTurn
        {
            get;
            private set;
        }

        /// <summary>
        /// ずっと付与するか
        /// </summary>
        private readonly bool isAllTheWay;

        public bool CanRemove => !isAllTheWay && RemainingTurn <= 0;

        public AbnormalStateType AbnormalStateType { get; }

        protected BattleCharacter Owner { get; }

        protected BattleSystem BattleSystem { get; }

        public AbnormalStateElement(int remainingTurn, bool isAllTheWay, AbnormalStateType abnormalStateType, BattleCharacter owner, BattleSystem battleSystem)
        {
            RemainingTurn = remainingTurn;
            this.isAllTheWay = isAllTheWay;
            AbnormalStateType = abnormalStateType;
            Owner = owner;
            BattleSystem = battleSystem;
        }

        public IObservable<Unit> OnEndTurn()
        {
            return Observable.Defer(() =>
            {
                RemainingTurn--;

                return OnEndTurnInternal();
            });
        }

        protected virtual IObservable<Unit> OnEndTurnInternal()
        {
            Debug.Log($"Hello {AbnormalStateType}");
            return Observable.ReturnUnit();
        }
    }
}
