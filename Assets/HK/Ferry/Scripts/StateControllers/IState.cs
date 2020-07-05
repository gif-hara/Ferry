using UniRx;

namespace HK.Ferry.StateControllers
{
    /// <summary>
    /// ステートのインターフェイス
    /// </summary>
    public interface IState
    {
        void Enter();

        void Exit();

        CompositeDisposable Disposables { get; }

        string StateName { get; }
    }
}
