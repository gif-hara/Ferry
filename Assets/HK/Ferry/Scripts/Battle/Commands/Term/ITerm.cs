using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.CommandData.Terms
{
    /// <summary>
    /// コマンドを実行する条件を持つインターフェイス
    /// </summary>
    public interface ITerm
    {
        string Description { get; }
    }
}
