using UnityEngine;
using Zenject;

namespace SimFactor.Utils
{
    public class MonoComponentMemoryPoolInstaller : MonoInstaller
    {
        [SerializeField] private MemoryPoolSettings _ItemsMemoryPoolSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<MonoComponentMemoryPool>().AsCached().WithArguments(_ItemsMemoryPoolSettings).NonLazy();
        }
    }
}
