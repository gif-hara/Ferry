using HK.Ferry.ActorControllers;
using HK.Ferry.Database;
using HK.Ferry.Extensions;
using HK.Ferry.StateControllers;
using HK.Framework.EventSystems;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers.States
{
    /// <summary>
    /// パーティを生成するステート
    /// </summary>
    public sealed class CreateParties : IState
    {
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public CompositeDisposable Disposables => disposables;

        public string StateName => nameof(CreateParties);

        private readonly MasterDataParty.Record playerParty;

        private readonly Transform playerParent;

        private readonly MasterDataParty.Record enemyParty;

        private readonly Transform enemyParent;

        private readonly Actor actorPrefab;

        public CreateParties(
            MasterDataParty.Record playerParty,
            Transform playerParent,
            MasterDataParty.Record enemyParty,
            Transform enemyParent,
            Actor actorPrefab
            )
        {
            this.playerParty = playerParty;
            this.playerParent = playerParent;
            this.enemyParty = enemyParty;
            this.enemyParent = enemyParent;
            this.actorPrefab = actorPrefab;
        }

        public void Enter(StateController owner)
        {
            var playerParty = new Party(this.playerParty.CreateActors(this.actorPrefab, this.playerParent));
            var enemyParty = new Party(this.enemyParty.CreateActors(this.actorPrefab, this.enemyParent));

            Broker.Global.Publish(BattleEvents.CreatedPlayerParty.Get(playerParty));
            Broker.Global.Publish(BattleEvents.CreatedEnemyParty.Get(enemyParty));

            owner.Change(nameof(BattleStart));
        }

        public void Exit()
        {
        }
    }
}
