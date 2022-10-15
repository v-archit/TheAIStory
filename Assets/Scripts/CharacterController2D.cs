using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    private float speed;
	[SerializeField]
	private float jumpHeight;
	[SerializeField]
    private float walkAcceleration;
	[SerializeField]
	private float airAcceleration;
	[SerializeField]
	private float groundDeceleration;

    public TextMeshProUGUI gameStatus;

    private Vector2 velocity;
	private float moveInput;
    private Collider2D[] hits;
    private bool grounded = false;
    private float acceleration;
    private float deceleration;
    public BoxCollider2D boxCollider;

    private void Start()
    {
        Jump();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        
        if (grounded)
        {
            velocity.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                //kinematics 3rd : v2 - u2 = 2as;
                Jump();
            }
        }

        acceleration = grounded ? walkAcceleration : airAcceleration;
        deceleration = grounded ? groundDeceleration : 0;

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

		//natural gravity
		velocity.y += Physics2D.gravity.y * Time.deltaTime;

		//actual translation
		transform.Translate(velocity * Time.deltaTime);

        grounded = false;

        hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);
        foreach (Collider2D hit in hits)
        {
            if (hit == boxCollider)
                continue;

            if (hit.tag == "AI")
            {
                gameStatus.text = "GAME OVER!";
                Time.timeScale = 0;
            }

            if (hit.tag == "Door")
            {
				gameStatus.text = "WELL DONE!";
				Time.timeScale = 0;
			}

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    grounded = true;
                }
            }
        }
    }

    void Jump()
    {
		velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));

	}
}
