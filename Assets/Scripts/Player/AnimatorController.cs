using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorController : MonoBehaviour
{
    public PlayerTrigger playerTrigger;
    private Animator animator;

    private string trJump = "jump";
    private string trDead = "dead";

    private int Jump;
    private int Dead;

    private bool canJump = true;
    void Start()
    {
        animator = GetComponent<Animator>();

        Jump = Animator.StringToHash(trJump);
        Dead = Animator.StringToHash(trDead);
    }

    void Update()
    {
        if (!playerTrigger.isAlive)
        {
            animator.SetBool(Dead, true);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {

        Vector2 input = context.ReadValue<Vector2>();

        if (input.magnitude > 1f) return; //대각선 막기

        if (context.performed) //누른 상태에서 
        {
            if (input.magnitude > 0f) //값이 0보다 크면
            {
                animator.SetBool(Jump, true); //jump true
            }
        }
        else if (context.canceled) //땐 상태
        {
            animator.SetBool(Jump, false); //jump false
        }
    }


}
