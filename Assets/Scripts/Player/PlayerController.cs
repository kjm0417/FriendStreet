using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveValue;
    public float distance = 1;

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
            // X축과 Z축으로만 이동하도록 변경
            moveValue = new Vector3(input.x * distance, 0, input.y * distance);

            // 플레이어의 위치 갱신
            transform.position += moveValue;
        }
        else if (context.canceled)
        {
            // 입력이 취소되면 moveValue를 초기화 (옵션)
            moveValue = Vector3.zero;
        }

    }

}
