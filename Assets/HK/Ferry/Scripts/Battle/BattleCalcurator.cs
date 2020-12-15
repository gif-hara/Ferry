using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public static class BattleCalcurator
    {
        public static int GetDamage(CharacterStatus attacker, CharacterStatus defenser, float rate)
        {
            try
            {
                checked
                {
                    var attack = attacker.attack.Value * rate;
                    var defenserG = Mathf.Max(defenser.greatPower.Value, 0.1f);
                    var defenserB = Mathf.Max(defenser.artistPower.Value, 0.1f);
                    var defenserN = Mathf.Max(defenser.wisdomPower.Value, 0.1f);
                    var g = attacker.greatPower.Value / defenserG;
                    var b = attacker.artistPower.Value / defenserB;
                    var n = attacker.wisdomPower.Value / defenserN;

                    return Mathf.Min((int)(attack * g * b * n), 99999);
                }
            }
            catch
            {
                return 99999;
            }
        }

        public static float GetDamageFloat(CharacterStatus attacker, CharacterStatus defenser, float rate)
        {
            var attack = attacker.attack.Value * rate;
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
