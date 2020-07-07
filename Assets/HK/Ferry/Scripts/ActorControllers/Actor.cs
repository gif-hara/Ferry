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

        public ActorSpec Spec
        {
            get;
            private set;
        }

        public ActorStatus Status
        {
            get;
            private set;
        }

        public ActorModel Model
        {
            get;
            private set;
        }

        public Actor Clone(ActorSpec spec)
        {
            var instance = Instantiate(this);
            instance.Spec = spec;
            instance.Status = new ActorStatus(spec);
            instance.Model = Instantiate(spec.ModelPrefab, instance.transform);
            instance.Model.transform.localPosition = Vector3.zero;
            instance.Model.transform.localRotation = Quaternion.identity;

            return instance;
        }
    }
}
