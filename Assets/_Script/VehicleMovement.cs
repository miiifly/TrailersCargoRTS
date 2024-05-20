using UnityEngine;
using UnityEngine.AI;

namespace Vehicle
{
    public class VehicleMovement : MonoBehaviour, IVehicleMovement
    {

        [SerializeField]
        private GameObject _vehicleModel;
        [SerializeField]
        private Transform _frontRayCast;
        [SerializeField]
        private Transform _backRayCast;
        [SerializeField]
        private Transform _steeringWheel;


        [SerializeField]
        private VehicleSettings _vehicleSettings;


        private NavMeshAgent _agent;

        private Quaternion _zeroSteeringRotation;

        private int _currentMoveSide;
        private int _currentTurnSide;

        private float _speedTresholdToStop = 0.3f;

        private float _currentWheelRotation = 0f;
        private float _currentSpeed = 0f;
        private float _wheelMaxAngle = 0f;
        private float _steeringWheelAngle = 0f;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _zeroSteeringRotation = _steeringWheel.localRotation;

            var wheelAngle = Mathf.Rad2Deg * Mathf.Atan(_vehicleSettings.WheelBase / (_vehicleSettings.TurnRadius - (_vehicleSettings.RearTrack / 2)));
            Quaternion wheelQuaternionRotation = Quaternion.Euler(0f, wheelAngle, 0f);
            _wheelMaxAngle = wheelQuaternionRotation.eulerAngles.y;
        }


        void IVehicleMovement.UpdateRotation(int steerSide)
        {
            _currentTurnSide = steerSide;
            var currentRotation = transform.eulerAngles.y;
            _currentWheelRotation = Mathf.Lerp(_currentWheelRotation, _currentMoveSide * steerSide * _wheelMaxAngle, Time.deltaTime * _vehicleSettings.WheelTurnSpeed);

            Quaternion vehicleAngle = Quaternion.Euler(transform.eulerAngles.x, currentRotation + _currentWheelRotation, transform.eulerAngles.z);

            transform.rotation = Quaternion.Lerp(transform.rotation, vehicleAngle, _currentSpeed / 4 * Time.deltaTime);

            TurnSteeringWheel();
        }

        private void TurnSteeringWheel()
        {
            _steeringWheelAngle = Mathf.LerpAngle(_steeringWheelAngle, _currentWheelRotation * _currentTurnSide, _vehicleSettings.WheelTurnSpeed * Time.deltaTime);
            _steeringWheelAngle = _currentMoveSide > 0 ? Mathf.Min(_steeringWheelAngle, _wheelMaxAngle, _currentWheelRotation) : Mathf.Max(_steeringWheelAngle, -_wheelMaxAngle, -_currentWheelRotation);

            var moduleAngle = Mathf.Abs(_steeringWheelAngle);
            var wheelAngle = (moduleAngle > 180f) ? moduleAngle - 360f : moduleAngle;

            float normalizedWheelRotation = Mathf.Clamp(wheelAngle * _currentMoveSide, -_wheelMaxAngle, _wheelMaxAngle);
            float steeringWheelRotation = normalizedWheelRotation * (_vehicleSettings.MaxSteeringWheelAngle / _wheelMaxAngle);
            float clampedSteeringWheelRotation = Mathf.Clamp(steeringWheelRotation, -_vehicleSettings.MaxSteeringWheelAngle, _vehicleSettings.MaxSteeringWheelAngle);
            _steeringWheel.localRotation = Quaternion.Euler(_zeroSteeringRotation.eulerAngles.x,_zeroSteeringRotation.eulerAngles.y, clampedSteeringWheelRotation + _zeroSteeringRotation.eulerAngles.z);
        }

        void IVehicleMovement.UpdateMovement(int side, float maxSpeed)
        {
            if (side == 0)
                return;
            float accelerationValue = _vehicleSettings.MotorInputCurve.Evaluate(Mathf.Clamp01(_currentSpeed / maxSpeed));

            if (_currentSpeed > maxSpeed)
            {
                accelerationValue = _vehicleSettings.BrakeTorque;
            }

            if (_currentMoveSide != side)
            {
                maxSpeed = 0;
                accelerationValue = _vehicleSettings.BrakeTorque * _vehicleSettings.HandBrakingMultiplier;

                if (_currentSpeed <= _speedTresholdToStop)
                {
                    _currentMoveSide = side;
                    _currentSpeed = 0;
                }
            }
            else
            {
                _currentMoveSide = side;
            }

            if (_currentSpeed == 0 && maxSpeed == 0)
                return;

            _currentSpeed = Mathf.Lerp(_currentSpeed, maxSpeed, Time.deltaTime * accelerationValue);
            _currentSpeed = Mathf.Min(_currentSpeed, _vehicleSettings.MaxSpeedMps);
            _agent.Move(_currentMoveSide * _currentSpeed * Time.deltaTime * transform.forward);
        }


        void IVehicleMovement.UdpateSuspension()
        {
            Vector3 forwardRayOrigin = _frontRayCast.position;
            Vector3 backwardRayOrigin = _backRayCast.position;

            if (Physics.Raycast(forwardRayOrigin, -_vehicleModel.transform.up, out var hitForward, _vehicleSettings.TurnRadius, NavMesh.AllAreas, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawLine(forwardRayOrigin, hitForward.point, Color.red);
            }

            if (Physics.Raycast(backwardRayOrigin, -_vehicleModel.transform.up, out var hitBackward, _vehicleSettings.TurnRadius, NavMesh.AllAreas, QueryTriggerInteraction.Ignore))
            {

                Debug.DrawLine(backwardRayOrigin, hitBackward.point, Color.blue);
            }

            if (hitForward.collider != null && hitBackward.collider != null)
            {
                Vector3 averageNormal;

                if (_currentMoveSide == 1)
                {
                    averageNormal = hitForward.normal.normalized;
                }
                else
                {
                    averageNormal = hitBackward.normal.normalized;
                }

                Quaternion slopeRotation = Quaternion.FromToRotation(_vehicleModel.transform.up, averageNormal) * _vehicleModel.transform.localRotation;

                slopeRotation = Quaternion.Euler(slopeRotation.eulerAngles.x, _vehicleModel.transform.localRotation.eulerAngles.y, _vehicleModel.transform.localRotation.eulerAngles.z);

                _vehicleModel.transform.localRotation = Quaternion.RotateTowards(_vehicleModel.transform.localRotation, slopeRotation, Time.deltaTime * _vehicleSettings.SlopeTorqueMultiplier);

            }
        }
    }
}