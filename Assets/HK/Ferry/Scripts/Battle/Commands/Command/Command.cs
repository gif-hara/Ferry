using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using HK.Ferry.BattleControllers;
using HK.Ferry.CommandData.Terms;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.CommandData.Commands
{
    /// <summary>
    /// コマンドの抽象クラス
    /// </summary>
    public abstract class Command : ICommand
    {
        [SerializeField, TermsPopup]
        private string nameLocalizeKey;

        public abstract void Invoke(Actor invoker, IReadOnlyList<Actor> targets);

        public abstract IReadOnlyList<Actor> GetAvailableTargets(ITerm term, Actor invoker, BattleEnvironment battleEnvironment);
    }
}
