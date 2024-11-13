using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Car : MonoBehaviour
{
    private float speed;
    private Material material;
    private Vector3 moveDirection;

    public void Initialize(CarDataSO carData, Vector3 direction)
    {
        speed = carData.speed;
        material = carData.material;
        moveDirection = direction;
        // MeshRenderer에 Material 적용
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.material = material;
        }
    }

    private void Update()
    {
        // 자동차가 일정한 속도로 이동하도록 업데이트
        transform.Translate(moveDirection * speed * Time.deltaTime);
        Debug.Log(moveDirection);

        // 화면을 벗어나면 파괴
        if (transform.position.x < -25f || transform.position.x > 25f) // x 좌표 기준
        {
           ObjectPoolManager.instance.ReturnToPool("Car", this.gameObject);
        }
    }
}
