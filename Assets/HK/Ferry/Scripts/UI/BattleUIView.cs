using System;
using System.Collections.Generic;
using HK.Ferry.Database;
using HK.Ferry.Extensions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

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

        [SerializeField]
        private CharacterStatusView enemyStatusView = default;
        public CharacterStatusView EnemyStatusView => enemyStatusView;

        [SerializeField]
        public CharacterStatusView playerStatusView = default;
        public CharacterStatusView PlayerStatusView => playerStatusView;

        private Subject<MasterDataCommand.Record> selectCommandSubject = new Subject<MasterDataCommand.Record>();
        public IObservable<MasterDataCommand.Record> SelectCommandAsObservable() => selectCommandSubject;

        private List<CommandButtonController> commandButtons = new List<CommandButtonController>();

        public void CreateCommandButton(IReadOnlyList<MasterDataCommand.Record> commands)
        {
            commandButtons.Clear();
            foreach (var command in commands)
            {
                var commandButton = Instantiate(commandButtonPrefab, commandButtonRoot, false);
                commandButton.Text.text = command.Id.AsLocalize();
                commandButton.Button.OnClickAsObservable()
                    .Subscribe(_ =>
                    {
                        selectCommandSubject.OnNext(command);
                    })
                    .AddTo(commandButton);
                commandButtons.Add(commandButton);
            }
        }

        public void SetCommandButtonInteractable(bool isInteractable)
        {
            foreach (var c in commandButtons)
            {
                c.Button.interactable = isInteractable;
            }
        }
    }
}
