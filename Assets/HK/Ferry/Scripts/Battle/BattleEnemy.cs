using HK.Ferry.AI;
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

        public BattleEnemy(CharacterSpec characterSpec, IAI ai) : base(characterSpec)
        {
            this.ai = ai;
        }

        public MasterDataCommand.Record GetCommand()
        {
            return ai.GetCommand();
        }
    }
}
