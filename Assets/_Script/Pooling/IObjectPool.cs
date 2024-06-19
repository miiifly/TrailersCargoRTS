using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPool<T> where T : IBaseSpawnable
{
    T Get(int typeId);
    void Release(T obj);
}
