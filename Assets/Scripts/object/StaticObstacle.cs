using UnityEngine;

public class StaticObstacle : ObstacleBase
{
    public override void Initialize(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        // 정적인 장애물은 방향을 필요로 하지 않으므로 direction은 무시
    }

}
