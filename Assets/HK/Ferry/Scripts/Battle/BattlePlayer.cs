using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BattlePlayer : BattleCharacter
    {
        public readonly List<string> Commands;

        public BattlePlayer(CharacterSpec characterSpec, List<string> commands) : base(characterSpec)
        {
            Commands = commands;
        }
    }
}
