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

        public ActorStatus BaseStatus
        {
            get;
            private set;
        }

        public ActorStatus InstanceStatus
        {
            get;
            private set;
        }

        public ActorModel Model
        {
            get;
            private set;
        }

        public Actor Clone(ActorStatus status)
        {
            var instance = Instantiate(this);
            instance.BaseStatus = status;
            instance.InstanceStatus = status.Clone;
            instance.Model = Instantiate(status.ModelPrefab, instance.transform);
            instance.Model.transform.localPosition = Vector3.zero;
            instance.Model.transform.localRotation = Quaternion.identity;

            return instance;
        }
    }
}
