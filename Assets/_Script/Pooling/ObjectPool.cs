using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPool<T> : IObjectPool<T> where T : IBaseSpawnable
{
    private readonly Dictionary<int, Queue<T>> _pools = new Dictionary<int, Queue<T>>();
    private readonly Dictionary<int, T> _prefabs;
    private readonly Transform _parent;
    private DiContainer _container;

    public ObjectPool(IEnumerable<T> prefabs, Transform parent, DiContainer container, int initialCapacity)
    {
        _parent = parent;
        _container = container;

        Initialize(prefabs, initialCapacity);
    }

    private void Initialize(IEnumerable<T> prefabs, int initialCapacity)
    {
        foreach (var pref in prefabs)
        {
            var key = pref.SpawnableTypeID;

            if (!_prefabs.ContainsKey(key))
            {
                _prefabs.Add(key, pref);

                _pools.Add(key, new Queue<T>());
                for (int i = 0; i < initialCapacity; i++)
                {
                    var obj = _container.InstantiatePrefab(pref.GameObject);
                    obj.transform.SetParent(_parent, false);
                    T spawnable = obj.GetComponent<T>();
                    obj.gameObject.SetActive(false);
                    _pools[key].Enqueue(spawnable);
                }
            }
        }
    }

    T IObjectPool<T>.Get(int typeId)
    {
        if (_pools.ContainsKey(typeId) && _pools[typeId].Count > 0)
        {
            T obj = _pools[typeId].Dequeue();
            obj.GameObject.SetActive(true);
            return obj;
        }

        if (_prefabs.ContainsKey(typeId))
        {
            var newObj = _container.InstantiatePrefab(_prefabs[typeId].GameObject);
            newObj.transform.SetParent(_parent, false);
            T spawnable = newObj.GetComponent<T>();
            return spawnable;
        }

        return default;
    }

    void IObjectPool<T>.Release(T obj)
    {
        obj.GameObject.SetActive(false);
        if (_pools.ContainsKey(obj.SpawnableTypeID))
        {
            _pools[obj.SpawnableTypeID].Enqueue(obj);
        }
        else
        {
            Debug.LogWarning($"Pool for type ID {obj.SpawnableTypeID} does not exist.");
        }
    }
}
