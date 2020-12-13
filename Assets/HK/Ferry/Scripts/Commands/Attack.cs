using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class Attack : ICommand
    {
        [SerializeField]
        private float rate = 1.0f;

        public IObservable<Unit> Invoke()
        {
            return Observable.Defer(() =>
            {
                Debug.Log("TODO Attack");

                return Observable.ReturnUnit();
            });
        }
    }
}
