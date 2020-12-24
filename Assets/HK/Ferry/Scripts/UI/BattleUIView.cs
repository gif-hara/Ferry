using System;
using System.Collections.Generic;
using HK.Ferry.BattleSystems;
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

        [SerializeField]
        private InformationView informationView = default;

        private Subject<BattlePlayer.CommandData> selectCommandSubject = new Subject<BattlePlayer.CommandData>();
        public IObservable<BattlePlayer.CommandData> SelectCommandAsObservable() => selectCommandSubject;

        private List<CommandButtonController> commandButtons = new List<CommandButtonController>();

        public void Setup(BattleSystem battleManager)
        {
            informationView.Setup(battleManager);
        }

        public void CreateCommandButton(IReadOnlyList<BattlePlayer.CommandData> commands)
        {
            commandButtons.Clear();
            foreach (var command in commands)
            {
                var commandButton = Instantiate(commandButtonPrefab, commandButtonRoot, false);
                commandButton.Setup(command);
                commandButton.Text.text = command.CommandName.AsLocalize();
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
                c.SetButtonInteractable(isInteractable);
            }
        }
    }
}
