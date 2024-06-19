using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEngine.ParticleSystem;

public class TrailerManager : MonoBehaviour
{
    [SerializeField]
    private Transform _initialTarget;

    private List<ITrailerComponent> _trailers = new List<ITrailerComponent>();

    [Inject]
    private ISpawner<ITrailerComponent> _trailerSpawner;

    private void OnEnable()
    {
        _trailerSpawner.OnSpawn += OnTrailerSpawned;
        _trailerSpawner.OnDespawn += OnTrailerDespawned;
    }

    private void OnDestroy()
    {
        _trailerSpawner.OnSpawn -= OnTrailerSpawned;
        _trailerSpawner.OnDespawn -= OnTrailerDespawned;
    }

    private void OnTrailerSpawned(ITrailerComponent trailer)
    {
        _trailers.Add(trailer);

        Transform target = _trailers.Count == 1 ? _initialTarget : _trailers[_trailers.Count - 2].Transform;
        trailer.SetFollowTarget(target);
    }

    private void OnTrailerDespawned(ITrailerComponent trailer)
    {
        _trailers.Remove(trailer);
    }

    //Can invoke some changes everywhere where use spawn 
    //_trailerSpawner.Spawn(trailerPrefab, true, trailer =>
    //{
    //   Some to do???
    //});

    public void SpawnTrailer(ITrailerComponent trailerPrefab)
    {
        _trailerSpawner.Spawn(trailerPrefab, true, null);
    }

    public void ClearAllTrailers()
    {
        _trailerSpawner.ClearSpawnedObjects();
    }
}
