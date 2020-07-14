using System;
using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.CommandData.Terms
{
    /// <summary>
    /// ランダムな<see cref="Actor"/>を選出する<see cref="ITerm"/>
    /// </summary>
    [Serializable]
    public sealed class Random : Term
    {
        public override IReadOnlyList<Actor> GetTargets(IReadOnlyList<Actor> targets)
        {
            return new List<Actor> { targets[UnityEngine.Random.Range(0, targets.Count)] };
        }
    }
}
