using UnityEngine;
using Zenject;

namespace SimFactor.Utils
{
    public class BasePoolableMono : MonoBehaviour, IPoolable
    {
        private Transform _poolParent;

        public void SetPoolParent(Transform poolParent)
        {
            _poolParent = poolParent;
        }

        void IPoolable.OnDespawned()
        {
            OnDespawned();
        }

        void IPoolable.OnSpawned()
        {
            OnSpawned();
        }

        protected virtual void OnDespawned()
        {
            gameObject.SetActive(false);
            gameObject.transform.SetParent(_poolParent);
        }

        protected virtual void OnSpawned()
        {
            gameObject.SetActive(true);
        }
    }
}
