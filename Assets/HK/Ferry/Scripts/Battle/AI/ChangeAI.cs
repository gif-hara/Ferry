using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.AI
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class ChangeAI
    {
        [SerializeReference, SubclassSelector]
        private ICondition condition = default;
        public ICondition Condition => condition;

        [SerializeField]
        private string nextAI = default;
        public string NextAI => nextAI;
    }
}
