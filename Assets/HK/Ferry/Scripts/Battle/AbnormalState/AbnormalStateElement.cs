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

        public bool CanRemove => RemainingTurn <= 0;

        public AbnormalStateType AbnormalStateType { get; }

        public AbnormalStateElement(int remainingTurn, AbnormalStateType abnormalStateType)
        {
            RemainingTurn = remainingTurn;
            AbnormalStateType = abnormalStateType;
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
