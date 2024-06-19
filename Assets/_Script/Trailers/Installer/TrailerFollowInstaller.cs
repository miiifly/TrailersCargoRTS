using UnityEngine;
using Zenject;

public class TrailerFollowInstaller : MonoInstaller
{
    [SerializeField]
    private float _followDistance;
    [SerializeField]
    private Transform _frontAxel;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TrailerFollow>().FromNew().AsSingle().WithArguments(_frontAxel, _followDistance).NonLazy();
    }
}
