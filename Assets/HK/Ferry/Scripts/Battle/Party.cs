using UnityEngine;
using UnityEngine.Assertions;
using HK.Ferry.ActorControllers;
using System.Collections.Generic;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// <see cref="Actor"/>をまとめるクラス
    /// </summary>
    public sealed class Party
    {
        public readonly List<Actor> Actors;

        public Party(List<Actor> actors)
        {
            this.Actors = actors;
        }
    }
}
