using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle
{
    public class VehicleAnimation : MonoBehaviour
    {
        [SerializeField]
        private List<WheelObject> _wheelObjects = new List<WheelObject>();

        [SerializeField]
        private Transform _vehicleTransform;
        private Vector3 _prewPosition;
        private Vector3 _velocity;
        private Vector3 _currentPosition;
        private Vector3 _previousPosition;
        private float _wheelRadius;
        private float _wheelRotationAngleAddition;

        VehicleAnimation(List<WheelObject> wheelObjects, Transform vehicleTransform, Vector3 prewPosition, Vector3 velocity, Vector3 currentPosition, Vector3 previousPosition, float wheelRadius)
        {
            _wheelObjects = wheelObjects;
            _vehicleTransform = vehicleTransform;
            _prewPosition = prewPosition;
            _velocity = velocity;
            _currentPosition = currentPosition;
            _previousPosition = previousPosition;
            _wheelRadius = wheelRadius;
        }

        void Update()
        {
            _currentPosition = _vehicleTransform.position;
            WheelSpining();

        }

        private void WheelSpining()
        {
            _velocity = (_currentPosition - _previousPosition) / Time.deltaTime;
            _wheelRotationAngleAddition = _velocity.magnitude * 360 * Time.deltaTime / (Mathf.PI * 2 * _wheelRadius);
        }

        private void WheelTurning()
        {
            foreach(WheelObject wheelObject in _wheelObjects)
            {
                //wheelObject.wheelRay.Rotate();
            }
        }
    }


}

