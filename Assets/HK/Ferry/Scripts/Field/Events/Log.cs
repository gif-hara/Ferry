using System;
using UniRx;
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

        public IDisposable Register(int x, int y, FieldStatus fieldStatus)
        {
            return fieldStatus.GetAccessed(x, y)
                .Skip(1)
                .Where(accessed => accessed)
                .Subscribe(_ =>
                {
                    Debug.Log(message);
                });
        }
    }
}
