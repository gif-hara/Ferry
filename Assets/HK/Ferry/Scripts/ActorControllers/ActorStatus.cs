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

        private readonly ReactiveProperty<bool> isDead;
        public readonly PropertyGetter<bool> IsDead;

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
            this.isDead = new ReactiveProperty<bool>(false);
            this.IsDead = new PropertyGetter<bool>(this.isDead);
            this.owner = owner;
        }

        public void UpdateTurnCharge()
        {
            this.turnCharge.Value += this.speed.Value * Time.deltaTime;
        }

        public bool IsEnoughTurnCharge => this.turnCharge.Value >= 1.0f;

        public void ResetTurnCharge()
        {
            this.turnCharge.Value = 0.0f;
        }

        public void TakeDamage(int damage)
        {
            var result = Mathf.Max(this.hitPoint.Value - damage, 0);
            this.hitPoint.Value = result;

            Debug.Log($"TakeDamage! {this.hitPoint.Value}");

            if (result <= 0)
            {
                this.Dead();
            }
        }

        private void Dead()
        {
            if (this.isDead.Value)
            {
                return;
            }

            this.isDead.Value = true;
            this.owner.gameObject.SetActive(false);
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
