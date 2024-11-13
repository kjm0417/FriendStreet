using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private PlayerTrigger playerTrigger;
    private PlayerController controller;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;

    private int coinCount = 0; // �÷��̾��� ����
    private float score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerTrigger = FindObjectOfType<PlayerTrigger>();
        controller = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinText.text = $"Coin : {coinCount}";
        scoreText.text = $"Score : {score} " ;
    }

    public void CollectCoin(GameObject coin) //���߿� ���ӸŴ����� �Ű��� ����
    {
        coinCount += 1; // ���� ȹ��
        Debug.Log("����: " + coinCount);

        // ���� ������Ʈ �ı�
        Destroy(coin);
    }

    public void ScoreUP()
    {
        float posChick = controller.chick.position.z;
        if(posChick>score)
        {
            score += 1;
        }
       
    }
}
