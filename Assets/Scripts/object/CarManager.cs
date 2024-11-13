using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public CarDataSO[] carDataArray;  // ���� �ڵ��� ScriptableObject �迭
    public GameObject carPrefab;  // �ڵ��� ������
    public GameObject[] spawnPoints;  // ���� ������
    public float minSpawnInterval = 3f;  // �ּ� ���� ����
    public float maxSpawnInterval = 6f;  // �ִ� ���� ����
    private int decision;  // ������, ���� ���� ����
    private int spawnCount; // ���� ��ġ ���� �� �ϳ��� �����ϱ� ���� ����

    private string carTag = "Car";

    private void Start()
    {
        decision = Random.Range(0, 2); // ���� �Ǵ� ������ ����
        StartCoroutine(SpawnCars());  // �ڵ��� ���� �ڷ�ƾ ����
    }

    private IEnumerator SpawnCars()
    {
        while (true)
        {
            // ������ ���� ���� ����
            spawnCount = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[spawnCount].transform.position;

            // ������ ���� ���� ����
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            GameObject car = ObjectPoolManager.instance.SpawnFromPool(carTag, spawnPosition, Quaternion.Euler(0, decision == 0 ? 0 : 180, 0));
            if (car != null)
            {
                CarDataSO carData = carDataArray[Random.Range(0, carDataArray.Length)];
                Car carComponent = car.GetComponent<Car>();
                if (carComponent != null)
                {
                    // SO �����͸� �̿��� �ڵ��� �ʱ�ȭ
                    Vector3 moveDirection = decision == 0 ? Vector3.right : Vector3.left;
                    carComponent.Initialize(carData, moveDirection);
                }
            }
        }
    }
}
