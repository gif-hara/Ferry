using System.Collections;
using System.Collections.Generic;
using HK.Ferry.FieldSystems;
using HK.Ferry.FieldSystems.Events;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static void AddUIImage(this IFieldEvent self, FieldCellButtonController controller)
        {
            Object.Instantiate(self.UIImagePrefab, controller.EventRoot.transform, false);
        }

        public static bool IsBlock(this IFieldEvent self)
        {
            return self is Block;
        }
    }
}
