using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.ActorControllers
{
    /// <summary>
    /// <see cref="Actor"/>のステータス
    /// </summary>
    public sealed class ActorStatus
    {
        private readonly ReactiveProperty<int> hitPoint;
        public readonly PropertyGetter<int> HitPoint;

        private readonly ReactiveProperty<int> hitPointMax;
        public readonly PropertyGetter<int> HitPointMax;

        private readonly ReactiveProperty<int> attack;
        public readonly PropertyGetter<int> Attack;

        private readonly ReactiveProperty<int> defense;
        public readonly PropertyGetter<int> Defense;

        private readonly ReactiveProperty<int> speed;
        public readonly PropertyGetter<int> Speed;

        private readonly ReactiveProperty<float> turnCharge;
        public readonly PropertyGetter<float> TurnCharge;

        private readonly Actor owner;

        public ActorStatus(Actor owner, ActorSpec actorSpec)
        {
            this.hitPoint = new ReactiveProperty<int>(actorSpec.HitPoint);
            this.HitPoint = new PropertyGetter<int>(this.hitPoint);
            this.hitPointMax = new ReactiveProperty<int>(actorSpec.HitPoint);
            this.HitPointMax = new PropertyGetter<int>(this.hitPointMax);
            this.attack = new ReactiveProperty<int>(actorSpec.Attack);
            this.Attack = new PropertyGetter<int>(this.attack);
            this.defense = new ReactiveProperty<int>(actorSpec.Defense);
            this.Defense = new PropertyGetter<int>(this.defense);
            this.speed = new ReactiveProperty<int>(actorSpec.Speed);
            this.Speed = new PropertyGetter<int>(this.speed);
            this.turnCharge = new ReactiveProperty<float>(0.0f);
            this.TurnCharge = new PropertyGetter<float>(this.turnCharge);
            this.owner = owner;
        }

        public void UpdateTurnCharge()
        {
            this.turnCharge.Value += this.speed.Value * Time.deltaTime;
        }

        public class PropertyGetter<T>
        {
            private readonly ReactiveProperty<T> stream;

            public IReactiveProperty<T> AsObservable() => this.stream;

            public T Get => this.stream.Value;

            public PropertyGetter(ReactiveProperty<T> stream)
            {
                this.stream = stream;
            }
        }
    }
}
