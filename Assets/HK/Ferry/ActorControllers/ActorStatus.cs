using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using System;

namespace HK.Ferry.ActorControllers
{
    /// <summary>
    /// <see cref="Actor"/>のステータス
    /// </summary>
    [Serializable]
    public sealed class ActorStatus
    {
        public string Name;

        public IntReactiveProperty HitPoint = new IntReactiveProperty();

        public IntReactiveProperty Attack = new IntReactiveProperty();

        public IntReactiveProperty Defense = new IntReactiveProperty();
    }
}
