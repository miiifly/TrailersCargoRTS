using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SimFactor.Utils
{
    public class MonoComponentMemoryPool
    {
        private readonly MemoryPoolSettings _settings;
        private readonly DiContainer _container;
        private readonly Dictionary<BasePoolableMono, MonoMemoryPool<BasePoolableMono>> _pools = new Dictionary<BasePoolableMono, MonoMemoryPool<BasePoolableMono>>();
        private readonly Dictionary<MonoMemoryPool<BasePoolableMono>, Transform> _poolsParents = new Dictionary<MonoMemoryPool<BasePoolableMono>, Transform>();

        public MonoComponentMemoryPool(
            DiContainer container,
            MemoryPoolSettings settings)
        {
            _settings = settings;
            if (_settings == null)
            {
                _settings = new MemoryPoolSettings();
            }
            _container = container;
        }

        public MonoMemoryPool<BasePoolableMono> InitializePoolIfNotExisting<TPrefab>(TPrefab prefab, MemoryPoolSettings settings = null) where TPrefab : BasePoolableMono
        {
            if (_pools.TryGetValue(prefab, out var pool))
            {
                return pool;
            }
            pool = CreatePool(prefab, settings);
            _pools.Add(prefab, pool);
            _poolsParents.Add(pool, new GameObject($"{prefab.GetType().Name}_MemoryPool").transform);
            Debug.Log($"Memory pool created for {prefab.GetType().Name}");
            return pool;
        }

        public TPrefab Spawn<TPrefab>(TPrefab prefab) where TPrefab : BasePoolableMono, IPoolable
        {
            var pool = InitializePoolIfNotExisting(prefab);

            var item = (TPrefab)pool.Spawn();
            item.SetPoolParent(_poolsParents[pool]);
            item.OnSpawned();
            return item;
        }

        private MonoMemoryPool<BasePoolableMono> CreatePool(BasePoolableMono prefab, MemoryPoolSettings settings = null)
        {
            if(settings== null)
            {
                settings = _settings;
            }
            return _container.Instantiate<MonoMemoryPool<BasePoolableMono>>(
                new object[]
                {
                    settings, new ComponentFromPrefabFactory<BasePoolableMono>(prefab, _container)
                });
        }
        public void Despawn(BasePoolableMono prefab, BasePoolableMono item)
        {
            _pools[prefab].Despawn(item);
            (item as IPoolable).OnDespawned();
        }
    }

    public class ComponentFromPrefabFactory<T> : IFactory<T> where T : Component
    {
        readonly DiContainer _container;
        readonly MonoBehaviour _prefab;

        public ComponentFromPrefabFactory(MonoBehaviour prefab, DiContainer container)
        {
            _container = container;
            _prefab = prefab;
        }

        public T Create()
        {
            return _container.InstantiatePrefabForComponent<T>(_prefab);
        }
    }
}
