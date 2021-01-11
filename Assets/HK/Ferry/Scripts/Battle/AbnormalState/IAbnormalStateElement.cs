using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.BattleSystems.BattleEvent;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAbnormalStateElement : IOnEndTurn
    {
        int RemainingTurn { get; }

        bool CanRemove { get; }

        AbnormalStateType AbnormalStateType { get; }
    }
}
