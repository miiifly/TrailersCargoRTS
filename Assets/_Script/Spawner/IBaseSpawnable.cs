using UnityEngine;

public interface IBaseSpawnable
{
    GameObject GameObject { get; }

    int SpawnableTypeID { get;  }
}
