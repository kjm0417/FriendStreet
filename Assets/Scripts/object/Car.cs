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
        // MeshRenderer�� Material ����
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.material = material;
        }
    }

    private void Update()
    {
        // �ڵ����� ������ �ӵ��� �̵��ϵ��� ������Ʈ
        transform.Translate(moveDirection * speed * Time.deltaTime);
        Debug.Log(moveDirection);

        // ȭ���� ����� �ı�
        if (transform.position.x < -25f || transform.position.x > 25f) // x ��ǥ ����
        {
           ObjectPoolManager.instance.ReturnToPool("Car", this.gameObject);
        }
    }
}
