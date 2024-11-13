using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CarData",menuName ="CarDataSO")]
public class CarDataSO : ScriptableObject
{
    public float speed;
    public Material material;
}
