using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.FieldSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class FieldEventBase : IFieldEvent
    {
        public abstract GameObject UIImagePrefab { get; }

        public abstract IDisposable Register(int x, int y, FieldStatus fieldStatus, FieldCellButtonController controller);
    }
}
