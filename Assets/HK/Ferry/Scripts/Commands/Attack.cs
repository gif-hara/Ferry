using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class Attack : ICommand
    {
        [SerializeField]
        private float rate = 1.0f;

        public void Invoke()
        {
            Debug.Log("TODO Attack");
        }
    }
}
