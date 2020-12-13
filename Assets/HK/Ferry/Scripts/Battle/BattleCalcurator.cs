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
            var attack = attacker.attack.Value;
            var defenserG = Mathf.Max(defenser.greatPower.Value, 0.1f);
            var defenserB = Mathf.Max(defenser.artistPower.Value, 0.1f);
            var defenserN = Mathf.Max(defenser.wisdomPower.Value, 0.1f);
            var g = attacker.greatPower.Value / defenserG;
            var b = attacker.artistPower.Value / defenserB;
            var n = attacker.wisdomPower.Value / defenserN;

            return attack * g * b * n;
        }
    }
}
