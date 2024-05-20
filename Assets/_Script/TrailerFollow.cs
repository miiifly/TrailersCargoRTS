using UnityEngine;

public class TrailerFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _followDistance;
    [SerializeField]
    private Transform _frontAxel;

    private Vector3 previuousPosition;
    private float speed;

    private void Awake()
    {
        previuousPosition = _target.position;
    }
    private void Update()
    {
        speed = Vector3.Distance(previuousPosition, _target.position) / Time.deltaTime;
        previuousPosition = _target.position;
        Vector3 targetPosition = new(_target.position.x, _frontAxel.position.y, _target.position.z);
        Vector3 targetForDistance = new(_target.position.x, transform.position.y, _target.position.z);
        Quaternion targetRotation = _target.rotation;


        Vector3 direction = targetForDistance - transform.position;

        if (direction.magnitude > _followDistance)
        {

            direction.Normalize();

            Vector3 newPosition = targetForDistance - (direction * _followDistance);

            transform.position = newPosition;
            transform.rotation = Quaternion.Lerp(transform.rotation, _frontAxel.rotation, Time.deltaTime * speed);
        }
        else if (direction.magnitude < _followDistance)
        {
            direction.Normalize();

            Vector3 newPosition = targetForDistance - (direction * _followDistance);

            transform.position = newPosition;
        }

        _frontAxel.LookAt(targetPosition);
    }
}