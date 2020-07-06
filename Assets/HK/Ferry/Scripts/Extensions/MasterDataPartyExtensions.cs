using UnityEngine;
using UnityEngine.Assertions;
using HK.Ferry.Database;
using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using System.Linq;

namespace HK.Ferry.Extensions
{
    /// <summary>
    /// <see cref="MasterDataParty"/>に関する拡張関数
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// モデルを作成する
        /// </summary>
        public static List<Actor> CreateActors(this MasterDataParty.Record self, Actor actorPrefab, Transform parent)
        {
            var result = new List<Actor>();
            var interval = 2.0f;
            var count = self.ActorIds.Count;
            var position = count == 1 ? 0.0f : -(interval / 2) - ((interval / 2) * count - 2);
            foreach (var record in self.ActorIds.Select(x => MasterDataActor.Get.GetRecord(x)))
            {
                var actor = actorPrefab.Clone(record.Status);
                actor.transform.SetParent(parent);
                actor.transform.localPosition = new Vector3(position, 0.0f, 0.0f);
                result.Add(actor);
                position += interval;
            }

            return result;
        }
    }
}
