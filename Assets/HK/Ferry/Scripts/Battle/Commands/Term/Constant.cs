using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.CommandData.Terms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class Constant : ITerm
    {
        [SerializeField]
        private bool constant;
    }
}
