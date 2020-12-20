using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.FieldSystems
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/FieldData")]
    public sealed class FieldData : ScriptableObject
    {
        public int width = default;

        public int height = default;

        public List<CellData> cellDatas = default;

        public int GetCellDataIndex(int x, int y)
        {
            return cellDatas.FindIndex(c => c.x == x && c.y == y);
        }

        public bool ContainsCellData(int x, int y)
        {
            return GetCellDataIndex(x, y) != -1;
        }
    }
}
