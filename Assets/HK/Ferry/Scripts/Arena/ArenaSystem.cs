using HK.Ferry.Database;
using HK.Ferry.GameSystems;
using UniRx;
using UnityEngine;

namespace HK.Ferry.ArenaSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ArenaSystem : GameSystem
    {
        [SerializeField]
        private RectTransform selectEnemyElementParent = default;

        [SerializeField]
        private SelectEnemyElement selectEnemyElementPrefab = default;

        [SerializeField]
        private DebugArenaData debugData = default;

        private void Start()
        {
            var enemies = MasterDataEnemy.Get.All;
            foreach (var e in enemies)
            {
                var element = Instantiate(selectEnemyElementPrefab, selectEnemyElementParent, false);
                element.Text.text = e.Spec.Name;
                element.Button.OnClickAsObservable()
                    .Subscribe(_ =>
                    {
                        Debug.Log("TODO バトル");
                    })
                    .AddTo(element);
            }
        }
    }
}
