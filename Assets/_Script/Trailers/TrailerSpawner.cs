using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrailerSpawner : BaseSpawner<ITrailerComponent>
{
    public TrailerSpawner(Transform spawnParent,
        DiContainer container,
        IEnumerable<ITrailerComponent> spawnables)
    : base(spawnParent, container, spawnables)
    {

    }

    protected override void SpawnInternal(ITrailerComponent spawnPrefab, bool setParent, Action<ITrailerComponent> spawnedCallback)
    {
        base.SpawnInternal(spawnPrefab, setParent, (trailer) =>
        {
            spawnedCallback.Invoke(trailer);
        });
    }
}
