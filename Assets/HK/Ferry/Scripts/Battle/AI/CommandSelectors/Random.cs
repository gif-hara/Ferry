using System;
using System.Collections.Generic;
using HK.Ferry.Database;
using HK.Ferry.Extensions;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.AI.CommandSelectors
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class Random : ICommandSelector
    {
        [SerializeField]
        private List<Element> elements = default;

        public MasterDataCommand.Record Get()
        {
            return MasterDataCommand.Get.GetRecord(elements.Lottery().CommandName);
        }

        [Serializable]
        public class Element : IWeight
        {
            [SerializeField, TermsPopup]
            private string commandName = default;
            public string CommandName => commandName;

            [SerializeField]
            private int weight = default;
            public int Weight => weight;
        }
    }
}
