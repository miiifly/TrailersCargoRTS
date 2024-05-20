using UnityEngine;
using Zenject;

namespace Vehicle
{
    public class VehicleMovementInstaller : MonoInstaller
    {
        [SerializeField]
        private VehicleMovement _vehicleMovement;
        public override void InstallBindings()
        {
            Container.Bind<IVehicleMovement>().FromInstance(_vehicleMovement).AsSingle().NonLazy();
        }
    }
}
