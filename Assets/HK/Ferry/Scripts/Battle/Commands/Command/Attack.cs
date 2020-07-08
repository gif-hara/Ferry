using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using UnityEngine;
using UnityEngine.Assertions;

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

        public override void Invoke(IReadOnlyList<Actor> targets)
        {
            Debug.Log("Attack!");
        }
    }
}
