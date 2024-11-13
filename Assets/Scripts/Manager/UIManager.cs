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

    private int coinCount = 0; // 플레이어의 코인
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

    public void CollectCoin(GameObject coin) //나중에 게임매니저로 옮겨줄 예정
    {
        coinCount += 1; // 점수 획득
        Debug.Log("코인: " + coinCount);

        // 코인 오브젝트 파괴
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
