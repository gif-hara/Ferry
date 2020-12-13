using System;
using System.Collections.Generic;
using HK.Ferry.Database;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class CharacterSpec
    {
        [SerializeField]
        private string name = default;
        public string Name => name;

        [SerializeField]
        private CharacterStatus status = default;
        public CharacterStatus Status => status;

        [SerializeField, TermsPopup]
        private List<string> commands = default;
        public List<string> Commands => commands;
    }
}
