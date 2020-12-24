using System;
using HK.Ferry.BattleSystems;
using UniRx;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommand
    {
        IObservable<Unit> Invoke(BattleSystem battleManager, BattleCharacter attacker, BattleCharacter target);
    }
}
