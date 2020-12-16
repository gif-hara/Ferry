using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.AI
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICondition
    {
        bool IsSatisfy(IOwner owner);
    }
}
