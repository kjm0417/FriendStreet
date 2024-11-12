using System.Collections.Generic;
using UnityEngine;

public class StaticSpawner : MonoBehaviour
{
    public ObstacleBase[] staticObstacles; // ������ ������ ��ֹ� �����յ� (����, ���� ��)
    public int obstacleCount = 5;          // ������ ��ֹ� ��
    public float spawnRangeX = 20f;         // x�� ���� ���� ����
    public float spawnRangeZ = 0;         // z�� ���� ���� ����
    public Transform player;               // �÷��̾��� Transform (�÷��̾� ��ġ�� �˱� ���� �ʿ�)

    private List<GameObject> spawnedObstacles = new List<GameObject>();

    private void Start()
    {
        SpawnStaticObstacles();
    }

    private void Update()
    {

        // �÷��̾�� �ڿ� �ִ� ��ֹ� �ı�
        for (int i = spawnedObstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = spawnedObstacles[i];

            // ������Ʈ�� �̹� �ı��Ǿ����� Ȯ��
            if (obstacle == null)
            {
                // ����Ʈ���� ���Ÿ� �ϰ� �Ѿ
                spawnedObstacles.RemoveAt(i);
                continue;
            }

            // �÷��̾�� �ڿ� �ִ� ��ֹ��� �ı�
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
            // ��ֹ� ������ ���� ����
            ObstacleBase staticObstaclePrefab = staticObstacles[Random.Range(0, staticObstacles.Length)];

            // ���� ��ġ ����
            Vector3 randomPosition = transform.position + new Vector3(Random.Range(-spawnRangeX, spawnRangeX),0,Random.Range(0, spawnRangeZ)
);

            // ��ֹ� ���� �� ��ġ �ʱ�ȭ
            GameObject obstacle = Instantiate(staticObstaclePrefab.gameObject, randomPosition, Quaternion.identity);
            spawnedObstacles.Add(obstacle);
        }
    }
}