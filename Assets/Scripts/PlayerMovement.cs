using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2DNew controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove, false, jump);

        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        Debug.Log("Landed");
    }
}
