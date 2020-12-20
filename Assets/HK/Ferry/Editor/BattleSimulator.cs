using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Editors
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/BattleSimulator")]
    public sealed class BattleSimulator : ScriptableObject
    {
        public CharacterStatus attacker;

        public CharacterStatus defenser;
    }
}
