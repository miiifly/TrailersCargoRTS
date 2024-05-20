using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float _gravityVelocity = 1;


    private void OnValidate()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(Physics.gravity.magnitude);
        Vector3 gravityPosition = transform.position;

        Vector3 gravityDirection = (gravityPosition - transform.position).normalized;

        Vector3 antiGravityForce = Physics.gravity.y * (-transform.up * rb.mass);

        rb.AddForceAtPosition(gravityPosition, -antiGravityForce * _gravityVelocity);
    }
}
