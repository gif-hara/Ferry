using HK.Ferry.StateControllers;
using UniRx;

namespace HK.Ferry.GameSystems
{
    /// <summary>
    /// ゲームステートの抽象クラス
    /// </summary>
    public abstract class GameStateBase : IState<GameManager.GameSystemType>
    {
        public CompositeDisposable ActiveDisposables { get; private set; } = new CompositeDisposable();

        public abstract GameManager.GameSystemType StateName { get; }

        public GameStateBase()
        {
        }

        public abstract void Enter(StateController<GameManager.GameSystemType> owner, IStateArgument argument = null);

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
