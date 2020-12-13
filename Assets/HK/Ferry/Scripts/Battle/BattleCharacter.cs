using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BattleCharacter
    {
        public CharacterSpec CharacterSpec
        {
            get;
            private set;
        }

        public BattleCharacter(CharacterSpec characterSpec)
        {
            CharacterSpec = characterSpec;
        }
    }
}
