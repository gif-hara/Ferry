using HK.Ferry.StateControllers;
using UniRx;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// バトルステートの抽象クラス
    /// </summary>
    public abstract class BattleStateBase : IState<BattleManager.BattlePhase>
    {
        public CompositeDisposable Disposables { get; private set; } = new CompositeDisposable();

        public abstract BattleManager.BattlePhase StateName { get; }

        public abstract void Enter(StateController<BattleManager.BattlePhase> owner);

        public void Exit()
        {
            OnExit();
            Disposables.Clear();
        }

        protected virtual void OnExit()
        {
        }
    }
}
