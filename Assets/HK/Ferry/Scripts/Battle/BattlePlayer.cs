using System.Collections.Generic;
using System.Linq;
using HK.Ferry.Database;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BattlePlayer : BattleCharacter
    {
        public readonly List<CommandData> Commands;

        public BattlePlayer(CharacterSpec characterSpec, List<string> commands) : base(characterSpec)
        {
            Commands = commands.Select(x => new CommandData(x)).ToList();
        }

        public override void StartTurn()
        {
            base.StartTurn();
            foreach (var c in Commands)
            {
                c.AddCoolTime();
            }
        }

        public class CommandData
        {
            public readonly string CommandName;

            private readonly IntReactiveProperty coolTime;
            public IReadOnlyReactiveProperty<int> CoolTimeAsObservable() => coolTime;

            private readonly MasterDataCommand.Record command;
            public MasterDataCommand.Record Command => command;

            public bool CanUse => coolTime.Value >= command.CoolTime;

            public CommandData(string commandName)
            {
                CommandName = commandName;
                command = MasterDataCommand.Get.GetRecord(CommandName);
                coolTime = new IntReactiveProperty(command.InitialCoolTime);
            }

            public void AddCoolTime()
            {
                ++coolTime.Value;
            }

            public void ResetCoolTime()
            {
                coolTime.Value = -1;
            }
        }
    }
}
