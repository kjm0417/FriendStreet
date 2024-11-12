using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    public abstract void Initialize(Vector3 position, Vector3 direction);
}
