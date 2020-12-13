using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

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

        public CharacterStatus(CharacterStatus characterStatus)
        {
            this.hitPoint = characterStatus.hitPoint;
            this.attack = characterStatus.attack;
            this.greatPower = characterStatus.greatPower;
            this.artistPower = characterStatus.artistPower;
            this.wisdomPower = characterStatus.wisdomPower;
        }

        public void Set(CharacterStatus other)
        {
            this.hitPoint = other.hitPoint;
            this.attack = other.attack;
            this.greatPower = other.greatPower;
            this.artistPower = other.artistPower;
            this.wisdomPower = other.wisdomPower;
        }
    }
}
