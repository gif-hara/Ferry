using System.Collections.Generic;
using HK.Ferry.ActorControllers;

namespace HK.Ferry.CommandData.Commands
{
    /// <summary>
    /// コマンドのデータを持つインターフェイス
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// コマンドを実行する
        /// </summary>
        void Invoke(IReadOnlyList<Actor> targets);
    }
}
