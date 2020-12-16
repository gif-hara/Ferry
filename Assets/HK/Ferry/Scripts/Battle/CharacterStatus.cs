using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

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

        public FloatReactiveProperty greatPower;

        public FloatReactiveProperty artistPower;

        public FloatReactiveProperty wisdomPower;

        public CharacterStatus(int hitPoint, int attack, float greatPower, float artistPower, float wisdomPower)
        {
            this.hitPoint = new IntReactiveProperty(hitPoint);
            this.attack = new IntReactiveProperty(attack);
            this.greatPower = new FloatReactiveProperty(greatPower);
            this.artistPower = new FloatReactiveProperty(artistPower);
            this.wisdomPower = new FloatReactiveProperty(wisdomPower);
        }

        public CharacterStatus(CharacterStatus other)
        {
            this.hitPoint = new IntReactiveProperty(other.hitPoint.Value);
            this.attack = new IntReactiveProperty(other.attack.Value);
            this.greatPower = new FloatReactiveProperty(other.greatPower.Value);
            this.artistPower = new FloatReactiveProperty(other.artistPower.Value);
            this.wisdomPower = new FloatReactiveProperty(other.wisdomPower.Value);
        }

        public void Set(CharacterStatus other)
        {
            this.hitPoint.Value = other.hitPoint.Value;
            this.attack.Value = other.attack.Value;
            this.greatPower.Value = other.greatPower.Value;
            this.artistPower.Value = other.artistPower.Value;
            this.wisdomPower.Value = other.wisdomPower.Value;
        }

        public float AddPower(float value, PowerType powerType, AddType addType)
        {
            var power = GetPower(powerType);
            const float min = 0.1f;
            const float max = 99.0f;
            switch (addType)
            {
                case AddType.Fixed:
                    power.Value = Mathf.Clamp(power.Value + value, min, max);
                    return value;
                case AddType.Percentage:
                    var result = power.Value * value;
                    power.Value = Mathf.Clamp(result, min, max);
                    return result;
                case AddType.Set:
                    power.Value = Mathf.Clamp(value, min, max);
                    return value;
                default:
                    Assert.IsTrue(false, $"{addType}は未対応です");
                    return value;
            }
        }

        public FloatReactiveProperty GetPower(PowerType powerType)
        {
            switch (powerType)
            {
                case PowerType.Great:
                    return greatPower;
                case PowerType.Artist:
                    return artistPower;
                case PowerType.Wisdom:
                    return wisdomPower;
                default:
                    Assert.IsTrue(false, $"{powerType}は未対応です");
                    return null;
            }
        }
    }
}
