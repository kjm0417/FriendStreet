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


        // �밢�� �̵� ����: �밢�� �Է��� ��쿡�� �Լ� ����
        if (input.magnitude > 1f)
        {
            return;
        }

        if (context.performed)
        {
            // performed ���¿����� �̵� ���� ���� (�̵��� ���� ����)
            moveValue = new Vector3(input.x * distance, 0, input.y * distance);
            chick.rotation = Quaternion.Euler(-90, moveValue.x * 90, 0);

            if(moveValue.z < 0f)
            {
                chick.rotation = Quaternion.Euler(-90, moveValue.z * 180, 0);
            }
        }
        else if (context.canceled)
        {
            // ��ư���� ���� �� ���� �̵��� ����
            jumpSound.Play();
            transform.position += moveValue;
            UIManager.Instance.ScoreUP();
            moveValue = Vector3.zero; // �̵� �� moveValue �ʱ�ȭ
        }

    }


 
}
