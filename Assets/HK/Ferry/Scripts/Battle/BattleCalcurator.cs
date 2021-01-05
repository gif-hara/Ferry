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

                    return (int)attack;
                }
            }
            catch
            {
                return 99999;
            }
        }
    }
}
