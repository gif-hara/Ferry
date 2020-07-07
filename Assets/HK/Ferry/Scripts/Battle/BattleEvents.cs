using HK.Framework.EventSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.BattleControllers
{
    /// <summary>
    /// バトルのイベントをまとめているクラス
    /// </summary>
    public static class BattleEvents
    {
        /// <summary>
        /// プレイヤーのパーティが作成された際のイベント
        /// </summary>
        public class CreatedPlayerParty : Message<CreatedPlayerParty, Party>
        {
            public Party Party => this.param1;
        }

        /// <summary>
        /// 敵のパーティ作成された際のイベント
        /// </summary>
        public class CreatedEnemyParty : Message<CreatedEnemyParty, Party>
        {
            public Party Party => this.param1;
        }
    }
}
