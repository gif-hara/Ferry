using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.ActorControllers
{
    /// <summary>
    /// オブジェクトの中枢を担うクラス
    /// </summary>
    public sealed class Actor : MonoBehaviour
    {
        public readonly IMessageBroker Broker = new MessageBroker();

        public ActorStatus Status
        {
            get;
            private set;
        }
    }
}
