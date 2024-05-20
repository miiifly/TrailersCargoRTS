using UnityEngine;
using Zenject;

namespace Vehicle
{
    public class VehicleController : MonoBehaviour
    {

        [SerializeField]
        private VehicleSettings _vehicleSettings;

        private VehicleInput _vehicleInput;
        [Inject]
        private IVehicleMovement _vehicleMovement;

        private int side = 0;
        protected float _steerInput;
        protected float _motorInput;

        private void Awake()
        {
            _vehicleInput = new VehicleInput();
        }

        private void Update()
        {
            _steerInput = _vehicleInput.TemplateVehicle.Steering.ReadValue<float>();
            _motorInput = _vehicleInput.TemplateVehicle.Acceleration.ReadValue<float>();

        }

        private void FixedUpdate()
        {
            float speed;

            if (_motorInput > 0)
            {
                side = 1;
                speed = _vehicleSettings.MaxAcceleration;
            }
            else if (_motorInput < 0)
            {
                side = -1;
                speed = _vehicleSettings.MaxAcceleration;
            }
            else
            {
                speed = 0;
            }

            int steerSide;

            if (_steerInput > 0)
            {
                steerSide = 1;
            }
            else if (_steerInput < 0)
            {
                steerSide = -1;
            }
            else
            {
                steerSide = 0;
            }

            Debug.Log(speed);
            _vehicleMovement.UpdateMovement(side, speed);
            _vehicleMovement.UpdateRotation(steerSide);
        }

        protected void OnEnable()
        {
            _vehicleInput.TemplateVehicle.Enable();

        }

        protected void OnDisable()
        {
            _vehicleInput.TemplateVehicle.Disable();
        }
    }
}

