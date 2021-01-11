using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AbnormalStateController
    {
        private readonly List<IAbnormalStateElement> elements = new List<IAbnormalStateElement>();

        private readonly BattleCharacter owner;

        private readonly BattleSystem battleSystem;

        public AbnormalStateController(BattleCharacter owner, BattleSystem battleSystem)
        {
            this.owner = owner;
            this.battleSystem = battleSystem;
        }

        public bool Add(AbnormalStateType abnormalStateType, bool isAllTheWay = false)
        {
            if (Contains(abnormalStateType))
            {
                return false;
            }

            elements.Add(AbnormalStateElementFactory.Create(abnormalStateType, isAllTheWay, owner, battleSystem));
            foreach (var s in owner.Skills.OfType<IModifiedAbnormalState>())
            {
                s.OnAddedAbnormalState(abnormalStateType, owner);
            }
            return true;
        }

        /// <summary>
        /// 状態異常を付与できるか抽選を行う
        /// </summary>
        public bool Lottery(AbnormalStateType abnormalStateType, float rate)
        {
            rate *= 1.0f - owner.CurrentSpec.Status.abnormalStateResistance.Get(abnormalStateType);
            var random = UnityEngine.Random.value;

            return rate > random;
        }

        public bool Contains(AbnormalStateType abnormalStateType)
        {
            return elements.FindIndex(x => x.AbnormalStateType == abnormalStateType) >= 0;
        }

        public IObservable<Unit> EndTurn()
        {
            return Observable.Defer(() =>
            {
                return Observable.Concat(elements.Select(x => x.OnEndTurn()))
                .DoOnCompleted(() =>
                {
                    for (var i = 0; i < elements.Count;)
                    {
                        var e = elements[i];
                        if (e.CanRemove)
                        {
                            elements.RemoveAt(i);
                            foreach (var s in owner.Skills.OfType<IModifiedAbnormalState>())
                            {
                                s.OnRemovedAbnormalState(e.AbnormalStateType, owner);
                            }
                        }
                        else
                        {
                            i++;
                        }
                    }
                })
                .AsSingleUnitObservable();
            });
        }
    }
}
