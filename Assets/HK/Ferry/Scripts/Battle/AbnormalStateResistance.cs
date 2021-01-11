using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using static HK.Ferry.Constants;

namespace HK.Ferry
{
    /// <summary>
    /// 状態異常の耐性値を持つクラス
    /// </summary>
    [Serializable]
    public sealed class AbnormalStateResistance
    {
        /// <summary>
        /// Inspector上で編集できる耐性値
        /// </summary>
        [SerializeField]
        private List<Element> elements = default;

        public readonly ReactiveDictionary<AbnormalStateType, FloatReactiveProperty> Resistances = new ReactiveDictionary<AbnormalStateType, FloatReactiveProperty>();

        private bool isInitialized = false;

        public AbnormalStateResistance()
        {
        }

        public AbnormalStateResistance(AbnormalStateResistance other)
        {
            other.Initialize();
            foreach (var x in other.Resistances)
            {
                Resistances.Add(x.Key, x.Value);
            }
        }

        public void Set(AbnormalStateType abnormalStateType, float value)
        {
            Initialize();
            if (!Resistances.ContainsKey(abnormalStateType))
            {
                Resistances.Add(abnormalStateType, new FloatReactiveProperty(value));
            }
            else
            {
                Resistances[abnormalStateType].Value = value;
            }
        }

        public float Get(AbnormalStateType abnormalStateType)
        {
            Initialize();
            if (Resistances.ContainsKey(abnormalStateType))
            {
                return Resistances[abnormalStateType].Value;
            }

            return 0.0f;
        }

        private void Initialize()
        {
            if (isInitialized)
            {
                return;
            }

            if (elements == default)
            {
                return;
            }

            foreach (var x in elements)
            {
                Set(x.abnormalStateType, x.value);
            }

            isInitialized = true;
        }

        [Serializable]
        public class Element
        {
            public AbnormalStateType abnormalStateType = default;

            [Range(0.0f, 1.0f)]
            public float value = default;
        }
    }
}
