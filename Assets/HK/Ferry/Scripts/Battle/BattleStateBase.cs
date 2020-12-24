using HK.Ferry.StateControllers;
using UniRx;

namespace HK.Ferry.BattleSystems
{
    /// <summary>
    /// バトルステートの抽象クラス
    /// </summary>
    public abstract class BattleStateBase : IState<BattleSystem.BattlePhase>
    {
        public CompositeDisposable ActiveDisposables { get; private set; } = new CompositeDisposable();

        public abstract BattleSystem.BattlePhase StateName { get; }

        protected BattleSystem battleManager;

        public BattleStateBase(BattleSystem battleManager)
        {
            this.battleManager = battleManager;
        }

        public abstract void Enter(StateController<BattleSystem.BattlePhase> owner, IStateArgument argument = null);

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
