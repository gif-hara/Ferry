using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.CommandData
{
    /// <summary>
    /// <see cref="CommandNode"/>をまとめるクラス
    /// </summary>
    [Serializable]
    public sealed class CommandBlueprint
    {
        [SerializeField]
        private List<CommandNode> nodes = default;
        public List<CommandNode> Nodes => this.nodes;
    }
}
