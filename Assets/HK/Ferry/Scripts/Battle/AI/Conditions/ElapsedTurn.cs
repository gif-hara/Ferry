using System;
using HK.Ferry.Extensions;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.AI.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class ElapsedTurn : ICondition
    {
        [SerializeField]
        private CompareType compareType = default;

        [SerializeField]
        private int turn = default;

        public bool IsSatisfy(IOwner owner)
        {
            return compareType.IsSatisfy(owner.ElapsedTurn, turn);
        }
    }
}
