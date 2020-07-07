using System;
using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// バトルの環境を制御するクラス
    /// </summary>
    public sealed class BattleEnvironment : MonoBehaviour
    {
        [SerializeField]
        private Transform playerParent = default;

        public Transform PlayerParent => this.playerParent;

        [SerializeField]
        private Transform enemyParent = default;

        public Transform EnemyParent => this.enemyParent;

        public Party PlayerParty { get; private set; }

        public Party EnemyParty { get; private set; }

        private void Awake()
        {
            Broker.Global.Receive<BattleEvents.CreatedPlayerParty>()
                .Subscribe(x => this.PlayerParty = x.Party)
                .AddTo(this);

            Broker.Global.Receive<BattleEvents.CreatedEnemyParty>()
                .Subscribe(x => this.EnemyParty = x.Party)
                .AddTo(this);
        }
    }
}

