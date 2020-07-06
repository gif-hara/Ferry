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

        [HideInInspector]
        public IntReactiveProperty HitPointMax = new IntReactiveProperty();

        public IntReactiveProperty HitPoint = new IntReactiveProperty();

        public IntReactiveProperty Attack = new IntReactiveProperty();

        public IntReactiveProperty Defense = new IntReactiveProperty();

        public IntReactiveProperty Speed = new IntReactiveProperty();

        [HideInInspector]
        public FloatReactiveProperty TurnCharge = new FloatReactiveProperty();

        [SerializeField]
        private ActorModel modelPrefab = default;

        public ActorModel ModelPrefab => this.modelPrefab;

        public ActorStatus Clone => new ActorStatus()
        {
            Name = this.Name,
            HitPointMax = new IntReactiveProperty(this.HitPoint.Value),
            HitPoint = new IntReactiveProperty(this.HitPoint.Value),
            Attack = new IntReactiveProperty(this.Attack.Value),
            Defense = new IntReactiveProperty(this.Defense.Value),
            Speed = new IntReactiveProperty(this.Speed.Value),
            TurnCharge = new FloatReactiveProperty(),
            modelPrefab = this.modelPrefab
        };
    }
}
