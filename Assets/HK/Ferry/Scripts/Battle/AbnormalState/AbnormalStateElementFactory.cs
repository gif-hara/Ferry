using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// 
    /// </summary>
    public static class AbnormalStateElementFactory
    {
        public static IAbnormalStateElement Create(AbnormalStateType abnormalStateType)
        {
            switch (abnormalStateType)
            {
                case AbnormalStateType.Poison:
                case AbnormalStateType.Paralysis:
                case AbnormalStateType.Confusion:
                case AbnormalStateType.BlindEyes:
                case AbnormalStateType.Flinch:
                case AbnormalStateType.Vitals:
                case AbnormalStateType.Quilting:
                case AbnormalStateType.Tiredness:
                case AbnormalStateType.Seal:
                case AbnormalStateType.Healing:
                case AbnormalStateType.MindEyes:
                case AbnormalStateType.Absorption:
                case AbnormalStateType.FastRunner:
                case AbnormalStateType.CounterAttack:
                    return new AbnormalStateElement(GetRemainingTurn(abnormalStateType), abnormalStateType);
                default:
                    Assert.IsTrue(false, $"{abnormalStateType}は未対応です");
                    return null;
            }
        }

        private static int GetRemainingTurn(AbnormalStateType abnormalStateType)
        {
            switch (abnormalStateType)
            {
                case AbnormalStateType.Poison:
                    return 5;
                case AbnormalStateType.Paralysis:
                    return 5;
                case AbnormalStateType.Confusion:
                    return 2;
                case AbnormalStateType.BlindEyes:
                    return 3;
                case AbnormalStateType.Flinch:
                    return 1;
                case AbnormalStateType.Vitals:
                    return 3;
                case AbnormalStateType.Quilting:
                    return 5;
                case AbnormalStateType.Tiredness:
                    return 3;
                case AbnormalStateType.Seal:
                    return 2;
                case AbnormalStateType.Healing:
                    return 5;
                case AbnormalStateType.MindEyes:
                    return 1;
                case AbnormalStateType.Absorption:
                    return 3;
                case AbnormalStateType.FastRunner:
                    return 1;
                case AbnormalStateType.CounterAttack:
                    return 5;
                default:
                    Assert.IsTrue(false, $"{abnormalStateType}は未対応です");
                    return 0;
            }
        }
    }
}
