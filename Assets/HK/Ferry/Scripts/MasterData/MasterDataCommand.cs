using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/Command")]
    public sealed class MasterDataCommand : MasterData<MasterDataCommand, MasterDataCommand.Record, string>
    {
        [Serializable]
        public class Record : IIdHolder<string>
        {
            [SerializeField, TermsPopup]
            private string name = default;

            public string Id => name;

            [SerializeReference, SubclassSelector]
            private List<ICommand> commands = default;
            public List<ICommand> Commands => commands;
        }

        public List<Record> GetRecords(IEnumerable<string> ids)
        {
            var result = new List<Record>();
            foreach (var id in ids)
            {
                result.Add(GetRecord(id));
            }

            return result;
        }
    }
}
