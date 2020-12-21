﻿using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.FieldSystems
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class DebugFieldData
    {
        public FieldData fieldData = default;

        public int initialX = default;

        public int initialY = default;
    }
}
