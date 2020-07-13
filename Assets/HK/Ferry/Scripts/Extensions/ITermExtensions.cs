using HK.Ferry.ActorControllers;
using HK.Ferry.BattleControllers;
using HK.Ferry.CommandData.Commands;
using HK.Ferry.CommandData.Terms;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Extensions
{
    /// <summary>
    /// <see cref="ITerm"/>に関する拡張関数
    /// </summary>
    public static partial class Extensions
    {
        public static bool CanInvoke(this ITerm self, Actor invoker, ICommand command, BattleEnvironment battleEnvironment)
        {
            return command.GetAvailableTargets(self, invoker, battleEnvironment).Count > 0;
        }
    }
}
