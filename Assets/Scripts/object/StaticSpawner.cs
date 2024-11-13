using System.Collections.Generic;
using UnityEngine;

public class StaticSpawner : MonoBehaviour
{
    public ObstacleBase[] staticObstacles; // 생성할 정적인 장애물 프리팹들 (코인, 나무 등)
    public int obstacleCount = 5;          // 생성할 장애물 수
    public int spawnRangeX = 20;         // x축 랜덤 생성 범위
    public float spawnRangeZ = 0;          // z축 랜덤 생성 범위
    public Transform player;               // 플레이어의 Transform (플레이어 위치를 알기 위해 필요)

    private List<GameObject> spawnedObstacles = new List<GameObject>();

    private void Start()
    {
        SpawnStaticObstacles();
    }

    private void Update()
    {

        // 플레이어보다 뒤에 있는 장애물 파괴
        for (int i = spawnedObstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = spawnedObstacles[i];

            // 오브젝트가 이미 파괴되었는지 확인
            if (obstacle == null)
            {
                // 리스트에서 제거만 하고 넘어감
                spawnedObstacles.RemoveAt(i);
                continue;
            }

            // 플레이어보다 뒤에 있는 장애물만 파괴
            if (player.position.z > obstacle.transform.position.z+4f)
            {
                Destroy(obstacle);
                spawnedObstacles.RemoveAt(i);
            }
        }
    }

    private void SpawnStaticObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            // 장애물 프리팹 랜덤 선택
            ObstacleBase staticObstaclePrefab = staticObstacles[Random.Range(0, staticObstacles.Length)];

            // 랜덤 위치 생성
            int RandomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 randomPosition = transform.position + new Vector3(RandomX, 0,Random.Range(0, spawnRangeZ));

            // 장애물 생성 및 위치 초기화
            GameObject obstacle = Instantiate(staticObstaclePrefab.gameObject, randomPosition, Quaternion.identity);
            spawnedObstacles.Add(obstacle);
        }
    }
}