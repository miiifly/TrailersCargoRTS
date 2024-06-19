using UnityEngine;
using Zenject;

public class BaseTrailerComponent : MonoBehaviour, ITrailerComponent
{
    [SerializeField]
    private TrailerType _trailerType;

    Transform ITrailerComponent.Transform => transform;

    GameObject IBaseSpawnable.GameObject => gameObject;
    int IBaseSpawnable.SpawnableTypeID => _trailerType.GetHashCode();

    [Inject]
    private TrailerFollow _trailerFollow;

    private void Awake()
    {
        _trailerFollow.Initialize();
    }

    void ITrailerComponent.SetFollowTarget(Transform target)
    {
        _trailerFollow.SetTarget(target);
    }
}
