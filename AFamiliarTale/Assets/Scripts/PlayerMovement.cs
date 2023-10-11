using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;
    float direction = 0;
    public float speed = 400;
    public float jumpForce = 5;
    bool onGround;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D playerRB;
    public Animator animator;

    //facing right or left
    bool faceRight = true;

    private void Awake() {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += context => {
            //direction to move player
            direction = context.ReadValue<float>();
        };

        controls.Land.Jump.performed += context => 
        {
            if(onGround) {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            }
        };
    }
  
    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        //move player
        playerRB.velocity = new Vector2(direction * speed + Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if((faceRight && direction < 0) || (!faceRight && direction > 0)) {
            Flip();
        }

    }


    void Flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
