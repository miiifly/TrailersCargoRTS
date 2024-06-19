using UnityEngine;
using Zenject;

public class TrailerFollow : ITickable, IInitializable
{
    private Transform _target;
    private float _followDistance;
    private Transform _frontAxel;
    private Transform _body;
    private Vector3 previuousPosition;
    private float speed;

    public TrailerFollow(Transform body, Transform frontAxel, float followDistance)
    {
        _body = body;
        _frontAxel = frontAxel;
        _followDistance = followDistance;
    }

    public void Initialize()
    {
        previuousPosition = _target.position;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Tick()
    {
        speed = Vector3.Distance(previuousPosition, _target.position) / Time.deltaTime;
        previuousPosition = _target.position;
        Vector3 targetPosition = new Vector3(_target.position.x, _frontAxel.position.y, _target.position.z);
        Vector3 targetForDistance = new Vector3(_target.position.x, _body.position.y, _target.position.z);
        Quaternion targetRotation = _target.rotation;

        Vector3 direction = targetForDistance - _body.position;

        if (direction.magnitude > _followDistance)
        {
            direction.Normalize();
            Vector3 newPosition = targetForDistance - (direction * _followDistance);
            _body.position = newPosition;
            _body.rotation = Quaternion.Lerp(_body.rotation, _frontAxel.rotation, Time.deltaTime * speed);
        }
        else if (direction.magnitude < _followDistance)
        {
            direction.Normalize();
            Vector3 newPosition = targetForDistance - (direction * _followDistance);
            _body.position = newPosition;
        }

        _frontAxel.LookAt(targetPosition);
    }
}
