using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public static class BattleCalcurator
    {
        public static int GetDamage(CharacterStatus attacker, CharacterStatus defenser)
        {
            return Mathf.FloorToInt(GetDamageFloat(attacker, defenser));
        }

        public static float GetDamageFloat(CharacterStatus attacker, CharacterStatus defenser)
        {
            var attack = attacker.attack;
            var defenserG = Mathf.Max(defenser.greatPower, 0.1f);
            var defenserB = Mathf.Max(defenser.bravePower, 0.1f);
            var defenserN = Mathf.Max(defenser.neatlyPower, 0.1f);
            var g = attacker.greatPower / defenserG;
            var b = attacker.bravePower / defenserB;
            var n = attacker.neatlyPower / defenserN;

            return attack * g * b * n;
        }
    }
}
