using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.FieldSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class Log : IFieldEvent
    {
        [SerializeField]
        private string message = default;

        public void Invoke()
        {
            Debug.Log(message);
        }
    }
}
