using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
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

        public bool Add(AbnormalStateType abnormalStateType)
        {
            if (Contains(abnormalStateType))
            {
                return false;
            }

            elements.Add(AbnormalStateElementFactory.Create(abnormalStateType, owner, battleSystem));
            return true;
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
                        if (elements[i].CanRemove)
                        {
                            elements.RemoveAt(i);
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
