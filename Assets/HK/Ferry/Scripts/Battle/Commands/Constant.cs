using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class Constant : ICommandCondition
    {
        [SerializeField]
        private bool constant;
    }
}
