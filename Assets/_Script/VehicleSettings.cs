
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "VehicleSetting", menuName = "CargoVr/Settings/VehicleSetting")]
public class VehicleSettings : ScriptableObject
{
    public LayerMask SurfaceLayer => _SurfaceLayer;
    public float BrakeTorque => _brakeTorque;
    public float MaxAcceleration => _maxAcceleration;
    public float HandBrakingMultiplier => _handBrakingMultiplier;
    public float MaxSpeedMps => _maxSpeedMPS;
    public float AdditionalTorqueMultiplierWhenSteering => _additionalTorqueMultiplierWhenSteering;
    public float SlopeTorqueMultiplier => _slopeToqueMultiplier;
    public float WheelTurnSpeed => _wheelTurnSpeed;


    public AnimationCurve NormalAcceleration => _normalAcceleration;
    public AnimationCurve MotorInputCurve => _motorInputCurve;
    public AnimationCurve HandBrakeCurve => _handBrakeCurve;

    public float WheelBase => _wheelBase;
    public float RearTrack => _rearTrack;
    public float TurnRadius => _turnRadius;
    public float WheelRadius => _wheelRadius;
    public float MaxSteeringWheelAngle => _maxSteeringWheelAngle;

    [SerializeField] private float _brakeTorque = 0.9f;
    [SerializeField] private float _maxAcceleration = 0.9f;
    [SerializeField] private float _maxSpeedMPS = 6.94444f;
    [SerializeField] private float _additionalTorqueMultiplierWhenSteering = 1f;
    [SerializeField] private float _slopeToqueMultiplier = 5f;
    [SerializeField] private float _handBrakingMultiplier = 10f;
    [SerializeField] private float _wheelTurnSpeed = 2f;


    [FormerlySerializedAs("_torqueToSpeedCurve")][SerializeField] private AnimationCurve _normalAcceleration;
    [SerializeField] private AnimationCurve _motorInputCurve;
    [SerializeField] private AnimationCurve _handBrakeCurve;

    [Header("Car Spaces")]
    [SerializeField] private float _wheelBase = 1.905f;
    [SerializeField] private float _rearTrack = 0.932f;
    [SerializeField] private float _turnRadius = 2.42f;
    [SerializeField] private float _wheelRadius = 1f;
    [SerializeField] private float _maxSteeringWheelAngle = 225f;

    [SerializeField] private LayerMask _SurfaceLayer;

}
