using System.Collections.Generic;
using HK.Ferry.AI;
using HK.Ferry.BattleSystems;
using HK.Ferry.BattleSystems.Skills;
using HK.Ferry.Database;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BattleEnemy : BattleCharacter
    {
        private IAI ai;

        public BattleEnemy(BattleSystem battleSystem, CharacterSpec characterSpec, List<ISkill> skills, IAI ai) : base(battleSystem, characterSpec, skills)
        {
            this.ai = ai;
        }

        public MasterDataCommand.Record GetCommand()
        {
            return ai.GetCommand();
        }
    }
}
