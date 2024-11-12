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


        // �밢�� �̵� ����: �밢�� �Է��� ��쿡�� �Լ� ����
        if (input.magnitude > 1f)
        {
            return;
        }

        if (context.performed)
        {
            // X��� Z�����θ� �̵��ϵ��� ����
            moveValue = new Vector3(input.x * distance, 0, input.y * distance);

            // �÷��̾��� ��ġ ����
            transform.position += moveValue;
        }
        else if (context.canceled)
        {
            // �Է��� ��ҵǸ� moveValue�� �ʱ�ȭ (�ɼ�)
            moveValue = Vector3.zero;
        }

    }

}
