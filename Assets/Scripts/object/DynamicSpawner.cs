using System.Collections;
using UnityEngine;

public class DynamicSpawner :MonoBehaviour
{
    public ObstacleBase[] movingObstacles;  // 동적인 장애물 프리팹들 (자동차, 기차 등)
    public GameObject[] spawnerPoints;  // 왼쪽과 오른쪽 스포너 위치들
    public float minSpawnInterval = 4f; // 최소 스폰 간격
    public float maxSpawnInterval = 5f; // 최대 스폰 간격
    private int decision;   //오른쪽 왼쪽
    private int spawnCount; //스폰 위치 개수중에 하나

    private void Start()
    {

        decision = Random.Range(0, 2);//왼쪽 오른쪽
        
        StartCoroutine(SpawnMovingObstacles());
    }

    private IEnumerator SpawnMovingObstacles()
    {
        while (true)
        {
            spawnCount = Random.Range(0, spawnerPoints.Length);
            Vector3 spawnPosition = spawnerPoints[spawnCount].transform.position;

            // 랜덤한 스폰 간격 설정
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            // 동적인 장애물 생성
            ObstacleBase movingObstaclePrefab = movingObstacles[Random.Range(0, movingObstacles.Length)];
            MovingObstacle movingObstacle = Instantiate(movingObstaclePrefab, spawnPosition, Quaternion.identity) as MovingObstacle;

            // 방향 설정 및 초기화 (왼쪽 스폰 지점이면 오른쪽으로, 오른쪽 스폰 지점이면 왼쪽으로 이동)
            Vector3 moveDirection = decision == 0 ? Vector3.right : Vector3.left;
            movingObstacle.Initialize(spawnPosition, moveDirection);
        }
    }
}