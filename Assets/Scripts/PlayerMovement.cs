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
        Debug.Log("Player Update: " + Time.time);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
            jump = true;
            Debug.Log("Button pressed " + transform.position.y);
        }
    }

    private void FixedUpdate()
    {
		Debug.Log("Player Fixed Update: " + Time.time);


		controller.Move(horizontalMove, false, jump);

        jump = false;

	}

	public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        Debug.Log("Landed " + transform.position.y);
    }
}
