using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.FieldSystems
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFieldEvent
    {
        IDisposable Register(int x, int y, FieldStatus fieldStatus);
    }
}
