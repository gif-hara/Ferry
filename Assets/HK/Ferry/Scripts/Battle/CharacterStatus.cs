using System;
using UniRx;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CharacterStatus
    {
        public IntReactiveProperty hitPoint;

        public IntReactiveProperty attack;

        public IntReactiveProperty defense;

        public IntReactiveProperty evasion;

        public IntReactiveProperty critical;

        public CharacterStatus(int hitPoint, int attack, int defense, int evasion, int critical)
        {
            this.hitPoint = new IntReactiveProperty(hitPoint);
            this.attack = new IntReactiveProperty(attack);
            this.defense = new IntReactiveProperty(defense);
            this.evasion = new IntReactiveProperty(evasion);
            this.critical = new IntReactiveProperty(critical);
        }

        public CharacterStatus(CharacterStatus other)
            : this(
                  other.hitPoint.Value,
                  other.attack.Value,
                  other.defense.Value,
                  other.evasion.Value,
                  other.critical.Value
                 )
        {
        }

        public void Set(CharacterStatus other)
        {
            this.hitPoint.Value = other.hitPoint.Value;
            this.attack.Value = other.attack.Value;
            this.defense.Value = other.defense.Value;
            this.evasion.Value = other.evasion.Value;
            this.critical.Value = other.critical.Value;
        }
    }
}
