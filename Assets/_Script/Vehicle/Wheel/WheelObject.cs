using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle
{
    [System.Serializable]
    class WheelObject : MonoBehaviour
    {
        [SerializeField] private Transform _wheelVisual;

        [Header("Wheel")]
        [SerializeField]
        private float _wheelRadius;

        [SerializeField] private bool _isRearSteeringWheel;
        [SerializeField] private bool _isLeft, _isRight;

        public Transform wheelRay => _wheelAnchor;
        public Transform wheelVisual => _wheelVisual;

        public bool isRearSteeringWheel => _isRearSteeringWheel;
        public bool isLeft => _isLeft;
        public bool isRight => _isRight;

        private Transform _wheelAnchor;


        private void Awake()
        {
            var go = new GameObject(gameObject.name);
            go.transform.SetParent(_wheelVisual.parent, false);
            go.transform.SetLocalPositionAndRotation(_wheelVisual.localPosition, Quaternion.identity);
            _wheelVisual.SetParent(go.transform, true);
            _wheelAnchor = go.transform;
        }
    }   

}


