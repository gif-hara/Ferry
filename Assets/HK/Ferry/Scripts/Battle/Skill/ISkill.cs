using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleSystems.Skills
{
    /// <summary>
    /// スキルのインターフェイス
    /// </summary>
    public interface ISkill
    {
        int Level { get; }
    }
}
