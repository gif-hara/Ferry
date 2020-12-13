using HK.Ferry.StateControllers;
using UniRx;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// バトルステートの抽象クラス
    /// </summary>
    public abstract class BattleStateBase : IState<BattleManager.BattlePhase>
    {
        public CompositeDisposable ActiveDisposables { get; private set; } = new CompositeDisposable();

        public abstract BattleManager.BattlePhase StateName { get; }

        protected BattleManager battleManager;

        public BattleStateBase(BattleManager battleManager)
        {
            this.battleManager = battleManager;
        }

        public abstract void Enter(StateController<BattleManager.BattlePhase> owner, IStateArgument argument = null);

        public void Exit()
        {
            OnExit();
            ActiveDisposables.Clear();
        }

        protected virtual void OnExit()
        {
        }
    }
}
