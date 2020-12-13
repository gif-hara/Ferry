using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct CharacterStatus
    {
        public int attack;

        public float greatPower;

        public float bravePower;

        public float neatlyPower;

        public CharacterStatus(int attack, float greatPower, float bravePower, float neatlyPower)
        {
            this.attack = attack;
            this.greatPower = greatPower;
            this.bravePower = bravePower;
            this.neatlyPower = neatlyPower;
        }

        public CharacterStatus(CharacterStatus characterStatus)
        {
            this.attack = characterStatus.attack;
            this.greatPower = characterStatus.greatPower;
            this.bravePower = characterStatus.bravePower;
            this.neatlyPower = characterStatus.neatlyPower;
        }

        public void Set(CharacterStatus other)
        {
            this.attack = other.attack;
            this.greatPower = other.greatPower;
            this.bravePower = other.bravePower;
            this.neatlyPower = other.neatlyPower;
        }
    }
}
