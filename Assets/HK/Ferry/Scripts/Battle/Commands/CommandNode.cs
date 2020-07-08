using System;
using UnityEngine;
using UnityEngine.Assertions;
using HK.Ferry.CommandData.Terms;
using HK.Ferry.CommandData.Commands;
using HK.Ferry.Database;

namespace HK.Ferry.CommandData
{
    /// <summary>
    /// <see cref="ITerm"/>と<see cref="ICommand"/>をまとめるクラス
    /// </summary>
    [Serializable]
    public sealed class CommandNode
    {
        [SerializeField]
        private int termId;
        public ITerm Term => MasterDataCommandTerm.Get.GetRecord(this.termId).Term;

        [SerializeField]
        private int commandId;
        public ICommand Command => MasterDataCommand.Get.GetRecord(this.commandId).Command;
    }
}
