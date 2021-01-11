using System;
using System.Collections.Generic;
using HK.Ferry.AI;
using HK.Ferry.BattleSystems;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/Enemy")]
    public sealed class MasterDataEnemy : MasterData<MasterDataEnemy, MasterDataEnemy.Record, int>
    {
        [Serializable]
        public class Record : IIdHolder<int>
        {
            [SerializeField]
            private int id = default;

            public int Id => id;

            [SerializeField]
            private CharacterSpec spec = default;
            public CharacterSpec Spec => spec;

            [SerializeField]
            private AIScriptableObject ai = default;
            public AIScriptableObject CreateAI() => Instantiate(ai);

            public BattleEnemy CreateBattleEnemy(BattleSystem battleSystem) => new BattleEnemy(battleSystem, spec, spec.CreateSkills(), CreateAI());
        }
    }
}
