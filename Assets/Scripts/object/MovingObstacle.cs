using UnityEngine;

public class MovingObstacle : ObstacleBase
{
    public float speed; // 이동 속도
    private Vector3 moveDirection;

    public override void Initialize(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        moveDirection = direction;
    }



    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // 화면을 벗어나면 파괴
        if (transform.position.x < -25f || transform.position.x > 25f) // x 좌표 기준
        {
            Destroy(gameObject);
        }
    }
}