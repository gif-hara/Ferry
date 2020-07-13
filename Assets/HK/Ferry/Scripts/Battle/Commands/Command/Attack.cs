using System.Collections.Generic;
using System.Linq;
using HK.Ferry.ActorControllers;
using HK.Ferry.BattleControllers;
using HK.Ferry.CommandData.Terms;
using UnityEngine;

namespace HK.Ferry.CommandData.Commands
{
    /// <summary>
    /// 攻撃を行う<see cref="ICommand"/>
    /// </summary>
    public sealed class Attack : Command
    {
        /// <summary>
        /// 攻撃力の係数
        /// </summary>
        [SerializeField]
        private float rate;

        public override void Invoke(Actor invoker, IReadOnlyList<Actor> targets)
        {
            foreach (var target in targets)
            {
                target.Status.TakeDamage(BattleCalculator.GetDamage(invoker, target));
            }
        }

        public override IReadOnlyList<Actor> GetAvailableTargets(ITerm term, Actor invoker, BattleEnvironment battleEnvironment)
        {
            return battleEnvironment.GetActors(invoker, term.TargetType).Where(x => !x.Status.IsDead.Get).ToArray();
        }
    }
}
