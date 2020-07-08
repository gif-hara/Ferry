using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// コマンドの抽象クラス
    /// </summary>
    public abstract class Command : ICommand
    {
        [SerializeField, TermsPopup]
        private string nameLocalizeKey;

        public abstract void Invoke(IReadOnlyList<Actor> targets);
    }
}
