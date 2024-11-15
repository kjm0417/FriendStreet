using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerTrigger : MonoBehaviour
{
    public bool isAlive = true; // 플레이어 생존 여부
    public AudioSource coinSound;
    public ParticleSystem particle = null;

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
            UIManager.Instance.CollectCoin(other.gameObject); // 코인 획득 처리
            coinSound.Play();
        }
    }

    public void Die()
    {
        isAlive = false;
        ParticleSystem.EmissionModule em = particle.emission;
        em.enabled = true;
        // 사망 로직 추가 (UI 켜지는거 추가)

    }

   
}
