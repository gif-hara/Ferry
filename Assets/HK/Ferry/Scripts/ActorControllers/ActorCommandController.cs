using HK.Ferry.BattleControllers;
using HK.Ferry.CommandData;
using HK.Ferry.Extensions;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.ActorControllers
{
    /// <summary>
    /// <see cref="Actor"/>のコマンドを制御するクラス
    /// </summary>
    public sealed class ActorCommandController
    {
        private readonly Actor owner;

        private CommandBlueprint blueprint;

        public ActorCommandController(Actor owner)
        {
            this.owner = owner;

            Assert.IsNotNull(this.owner);
            Assert.IsNotNull(this.owner.Spec);

            this.blueprint = this.owner.Spec.Blueprint;
        }

        public void Invoke(BattleEnvironment battleEnvironment)
        {
            foreach (var node in this.blueprint.Nodes)
            {
                var targets = node.Command.GetAvailableTargets(node.Term, this.owner, battleEnvironment);
                if (targets.Count <= 0)
                {
                    continue;
                }

                node.Command.Invoke(this.owner, node.Term.GetTargets(targets));
                break;
            }

            this.owner.Status.ResetTurnCharge();
        }
    }
}
