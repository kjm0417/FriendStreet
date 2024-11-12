using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerTrigger : MonoBehaviour
{
    public int score = 0; // �÷��̾��� ����
    public bool isAlive = true; // �÷��̾� ���� ����

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
            CollectCoin(other.gameObject); // ���� ȹ�� ó��
        }
    }

    private void Die()
    {
        isAlive = false;
        Debug.Log("Player is dead!");
        // ��� ���� �߰� (��: UI ������Ʈ, ���� ����� �ɼ� ��)
    }

    private void CollectCoin(GameObject coin) //���߿� ���ӸŴ����� �Ű��� ����
    {
        score += 1; // ���� ȹ��
        Debug.Log("����: " + score);

        // ���� ������Ʈ �ı�
        Destroy(coin);
    }
}
