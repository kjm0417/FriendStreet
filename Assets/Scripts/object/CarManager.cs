using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public CarDataSO[] carDataArray;  // 여러 자동차 ScriptableObject 배열
    public GameObject carPrefab;  // 자동차 프리팹
    public GameObject[] spawnPoints;  // 스폰 지점들
    public float minSpawnInterval = 3f;  // 최소 스폰 간격
    public float maxSpawnInterval = 6f;  // 최대 스폰 간격
    private int decision;  // 오른쪽, 왼쪽 결정 변수
    private int spawnCount; // 스폰 위치 개수 중 하나를 선택하기 위한 변수

    private string carTag = "Car";

    private void Start()
    {
        decision = Random.Range(0, 2); // 왼쪽 또는 오른쪽 결정
        StartCoroutine(SpawnCars());  // 자동차 스폰 코루틴 시작
    }

    private IEnumerator SpawnCars()
    {
        while (true)
        {
            // 랜덤한 스폰 지점 선택
            spawnCount = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[spawnCount].transform.position;

            // 랜덤한 스폰 간격 설정
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            GameObject car = ObjectPoolManager.instance.SpawnFromPool(carTag, spawnPosition, Quaternion.Euler(0, decision == 0 ? 0 : 180, 0));
            if (car != null)
            {
                CarDataSO carData = carDataArray[Random.Range(0, carDataArray.Length)];
                Car carComponent = car.GetComponent<Car>();
                if (carComponent != null)
                {
                    // SO 데이터를 이용해 자동차 초기화
                    Vector3 moveDirection = decision == 0 ? Vector3.right : Vector3.left;
                    carComponent.Initialize(carData, moveDirection);
                }
            }
        }
    }
}
