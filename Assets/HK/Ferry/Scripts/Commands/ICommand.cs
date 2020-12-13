using System;
using UniRx;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommand
    {
        IObservable<Unit> Invoke(BattleCharacter attacker, BattleCharacter target);
    }
}
