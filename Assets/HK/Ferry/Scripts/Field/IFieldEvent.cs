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
        IDisposable Register(int x, int y, FieldStatus fieldStatus, FieldCellButtonController controller);

        /// <summary>
        /// 識別される際の状態を返す
        /// </summary>
        Constants.IdentifyType OnIdentifiedType { get; }

        GameObject UIImagePrefab { get; }
    }
}
