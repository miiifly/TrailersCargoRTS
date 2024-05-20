using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGravity : MonoBehaviour
{
    [SerializeField]
    private Collider _floorCollider;
    [SerializeField]
    private MeshCollider _meshCollider;
    [SerializeField]
    private List<Transform> _wheelPosition = new List<Transform>();
    [SerializeField]
    private Rigidbody _rigidBody;
    [SerializeField]
    private float _suspensionDistance;
    [SerializeField]
    private float _suspension;

    private void OnValidate()
    {
        if(_rigidBody == null )
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

    }

    private void Awake()
    {
        
    }

    private void Update()
    {
        foreach(Transform wheel in _wheelPosition)
        {
            Vector3 collidehit = _floorCollider.ClosestPoint(wheel.position);
            float distance = Vector3.Distance(collidehit, wheel.position);
            Debug.Log($"{collidehit} {distance} Position wheel in world {wheel.position} ");
            if(distance< _suspensionDistance )
            {
                _rigidBody.AddForceAtPosition(_suspension * _rigidBody.mass / 4 * -Physics.gravity, wheel.position);
            }
        }    
    }
}
