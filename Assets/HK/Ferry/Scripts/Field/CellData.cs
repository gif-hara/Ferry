using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.FieldSystems
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class CellData
    {
        public int x = default;

        public int y = default;

        [SerializeReference, SubclassSelector]
        public List<IFieldEvent> fieldEvents = default;
    }
}
