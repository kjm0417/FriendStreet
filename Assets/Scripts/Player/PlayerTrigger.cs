using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerTrigger : MonoBehaviour
{
    public bool isAlive = true; // �÷��̾� ���� ����
    public AudioSource coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if (!isAlive) return;

        // ������ ��ֹ�(�ڵ���, ����)���� �浹 ó��
        if (other.CompareTag("MovingObstacle"))
        {
            Die(); // �÷��̾� ��� ó��
        }
        // ������ ���� ��ֹ�(����)���� �浹 ó��
        else if (other.CompareTag("StaticObstacle"))
        {
            Die(); // �÷��̾� ��� ó��
        }
        // ���ΰ��� �浹 ó��
        else if (other.CompareTag("Coin"))
        {
            UIManager.Instance.CollectCoin(other.gameObject); // ���� ȹ�� ó��
            coinSound.Play();
        }
    }

    public void Die()
    {
        isAlive = false;
        Debug.Log("Player is dead!");
        // ��� ���� �߰� (��: UI ������Ʈ, ���� ����� �ɼ� ��)
    }

   
}
