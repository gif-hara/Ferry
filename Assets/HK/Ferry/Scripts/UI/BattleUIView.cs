using System.Collections.Generic;
using HK.Ferry.Database;
using HK.Ferry.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BattleUIView : MonoBehaviour
    {
        [SerializeField]
        private Transform commandButtonRoot = default;

        [SerializeField]
        private CommandButtonController commandButtonPrefab = default;

        public void CreateCommandButton(IReadOnlyList<MasterDataCommand.Record> commands)
        {
            foreach (var command in commands)
            {
                var commandButton = Instantiate(commandButtonPrefab, commandButtonRoot, false);
                commandButton.Text.text = command.Id.AsLocalize();
                commandButton.Button.OnClickAsObservable()
                    .Subscribe(_ =>
                    {
                        Debug.Log($"TODO {command.Id.AsLocalize()}");
                    })
                    .AddTo(commandButton);
            }
        }
    }
}
