using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using System;
using HK.Ferry.CommandData;
using HK.Ferry.Database;

namespace HK.Ferry.ActorControllers
{
    /// <summary>
    /// <see cref="Actor"/>のスペック
    /// </summary>
    [Serializable]
    public sealed class ActorSpec
    {
        [SerializeField]
        private string name = default;
        public string Name => this.name;

        [SerializeField]
        private int hitPoint = default;
        public int HitPoint => this.hitPoint;

        [SerializeField]
        private int attack = default;
        public int Attack => this.attack;

        [SerializeField]
        private int defense = default;
        public int Defense => this.defense;

        [SerializeField]
        private int speed = default;
        public int Speed => this.speed;

        [SerializeField]
        private ActorModel modelPrefab = default;
        public ActorModel ModelPrefab => this.modelPrefab;

        [SerializeField]
        private int blueprintId = default;
        public CommandBlueprint Blueprint => MasterDataCommandBlueprint.Get.GetRecord(this.blueprintId).Blueprint;
    }
}
