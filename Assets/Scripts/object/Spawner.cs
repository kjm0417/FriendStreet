using System.Collections;
using UnityEngine;

public class Spawner :Behaviour
{
    //생성 오브젝트
    public GameObject obstaclePrefab;
    [Range(1, 5)] public float spawnInterval;
    public bool isLeft = false;
}