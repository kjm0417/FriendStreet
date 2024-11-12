using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerTrigger : MonoBehaviour
{
    public int score = 0; // 플레이어의 점수
    public bool isAlive = true; // 플레이어 생존 여부

    private void OnTriggerEnter(Collider other)
    {
        if (!isAlive) return;

        // 동적인 장애물(자동차, 기차)와의 충돌 처리
        if (other.CompareTag("MovingObstacle"))
        {
            Die(); // 플레이어 사망 처리
        }
        // 정적인 위험 장애물(나무)와의 충돌 처리
        else if (other.CompareTag("StaticObstacle"))
        {
            Die(); // 플레이어 사망 처리
        }
        // 코인과의 충돌 처리
        else if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject); // 코인 획득 처리
        }
    }

    private void Die()
    {
        isAlive = false;
        Debug.Log("Player is dead!");
        // 사망 로직 추가 (예: UI 업데이트, 게임 재시작 옵션 등)
    }

    private void CollectCoin(GameObject coin) //나중에 게임매니저로 옮겨줄 예정
    {
        score += 1; // 점수 획득
        Debug.Log("코인: " + score);

        // 코인 오브젝트 파괴
        Destroy(coin);
    }
}
