using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveValue;
    public float distance = 1;
    public Transform chick;

    [Header("Audio Source")]
    public AudioSource jumpSound;

    void Start()
    {
        moveValue = Vector3.zero;
    }

   
    void Update()
    {
        
    }



    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();


        // 대각선 이동 방지: 대각선 입력의 경우에는 함수 종료
        if (input.magnitude > 1f)
        {
            return;
        }

        if (context.performed)
        {
            // performed 상태에서는 이동 값만 설정 (이동은 하지 않음)
            moveValue = new Vector3(input.x * distance, 0, input.y * distance);
            chick.rotation = Quaternion.Euler(-90, moveValue.x * 90, 0);

            if(moveValue.z < 0f)
            {
                chick.rotation = Quaternion.Euler(-90, moveValue.z * 180, 0);
            }
        }
        else if (context.canceled)
        {
            // 버튼에서 손을 뗄 때만 이동을 수행
            jumpSound.Play();
            transform.position += moveValue;
            UIManager.Instance.ScoreUP();
            moveValue = Vector3.zero; // 이동 후 moveValue 초기화
        }

    }


 
}
