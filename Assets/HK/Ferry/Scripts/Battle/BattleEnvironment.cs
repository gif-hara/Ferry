using System;
using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using HK.Ferry.ActorControllers;
using System.Collections.Generic;
using static HK.Ferry.Constants;

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

        /// <summary>
        /// <paramref name="targetType"/>からターゲットとなる<see cref="Actor"/>を返す
        /// </summary>
        public List<Actor> GetActors(Actor actor, TargetType targetType)
        {
            switch (targetType)
            {
                case TargetType.Ally:
                    if (this.PlayerParty.Actors.IndexOf(actor) >= 0)
                    {
                        return this.PlayerParty.Actors;
                    }
                    else
                    {
                        return this.EnemyParty.Actors;
                    }
                case TargetType.Opponent:
                    if (this.PlayerParty.Actors.IndexOf(actor) >= 0)
                    {
                        return this.EnemyParty.Actors;
                    }
                    else
                    {
                        return this.PlayerParty.Actors;
                    }
                case TargetType.My:
                    return new List<Actor> { actor };
                default:
                    Assert.IsTrue(false, $"{targetType}は未対応です");
                    return null;
            }
        }
    }
}

