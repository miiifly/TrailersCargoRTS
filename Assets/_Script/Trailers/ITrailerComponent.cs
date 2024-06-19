using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrailerComponent : IBaseSpawnable
{
    Transform Transform { get; }
    void SetFollowTarget(Transform target);
}

public enum TrailerType
{
    None = 0,
}
