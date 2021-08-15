using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    private Rigidbody2D rb;
    private BoxCollider2D boxcollider2d;

    private float moveSpeed;
    public float speedMultiplier = 0.0f;
    private float moveInput;

    private float jumpForce;
    private float gravity;

    public float fallMultiplier = 2.5f;
    public float jumpFallMultiplier = 4f;
    private float extraColliderTest = 0.1f;

    private float wallJumpVelocity = 0.0f;
    private float wallJumpVelocityAdd = 6.0f;


    // Start is called before the first frame update
    void Start()
    {
        jumpForce = GameSettingsController.Instance.playerJumpHeight;
        gravity = GameSettingsController.Instance.playerGravity;

        rb = GetComponent<Rigidbody2D>();
        boxcollider2d = GetComponent<BoxCollider2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Hi Nick :)
        if (!GameStateManager.Instance.isGameFullyReady)
        {
            return;
        }

        moveSpeed = GameSettingsController.Instance.playerSpeed * speedMultiplier;


        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpFallMultiplier - 1) * Time.deltaTime;
        }

        //left and right jump drag
        if (wallJumpVelocity > 0.1)//going right
        {
            wallJumpVelocity -= wallJumpVelocityAdd * Time.deltaTime;
        }
        else if (wallJumpVelocity < -0.1)//going left
        {
            wallJumpVelocity += wallJumpVelocityAdd * Time.deltaTime;
        }
        else
        {
            wallJumpVelocity = 0;
        }




        //jump
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rb.velocity = Vector2.up * jumpForce;

                JimmyAnimationControls.Instance.SetJumpSquat();
            }

            if (IsOnWallRight())
            {
                Vector2 wallJump = Vector2.up;

                if (!IsGrounded())
                {
                    wallJumpVelocity = -wallJumpVelocityAdd;
                    wallJump = Vector2.up / 2;

                    JimmyAnimationControls.Instance.SetLiftOff();
                }

                rb.velocity = wallJump * jumpForce;

            }
            else if (IsOnWallLeft())
            {
                Vector2 wallJump = Vector2.up;

                if (!IsGrounded())
                {
                    wallJumpVelocity = wallJumpVelocityAdd;
                    wallJump = Vector2.up / 2;

                    JimmyAnimationControls.Instance.SetLiftOff();
                }

                rb.velocity = wallJump * jumpForce;

            }

        }

    }//Update

    void FixedUpdate()
    {
        //Hi Nick :)
        if (!GameStateManager.Instance.isGameFullyReady)
        {
            return;
        }

        moveInput = Input.GetAxis("Horizontal");

        if (moveInput >= 0 && IsOnWallRight() && !IsGrounded())//going right
        {
            moveInput = 0;

            if (wallJumpVelocity > 0)
            {
                wallJumpVelocity = 0;
            }

        }
        if (moveInput < 0 && IsOnWallLeft() && !IsGrounded())//going left
        {
            moveInput = 0;

            if (wallJumpVelocity < 0)
            {
                wallJumpVelocity = 0;
            }

        }

        //momentum fighting
        if (moveInput > 0 && wallJumpVelocity < -0.1)//going right
        {
            wallJumpVelocity += (moveInput * moveSpeed) * Time.deltaTime;
            moveInput = 0;
        }
        else if (moveInput < 0 && wallJumpVelocity > 0.1)//going left
        {
            wallJumpVelocity += (moveInput * moveSpeed) * Time.deltaTime;
            moveInput = 0;
        }

        rb.velocity = new Vector2((moveInput * moveSpeed) + wallJumpVelocity, rb.velocity.y);

    }

    public bool IsGrounded()
    {
        //down
        RaycastHit2D boxcastHit = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0, Vector2.down, extraColliderTest, platformLayerMask);
        if (boxcastHit.collider != null)
        {
            return true;
        }

        return false;

    }//IsGrounded

    public bool IsOnWallRight()
    {
        //right
        RaycastHit2D boxcastHit = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0, Vector2.right, extraColliderTest, platformLayerMask);
        if (boxcastHit.collider != null)
        {
            return true;
        }

        return false;
    }//IsOnWall

    public bool IsOnWallLeft()
    {
        //left
        RaycastHit2D boxcastHit = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0, Vector2.left, extraColliderTest, platformLayerMask);
        if (boxcastHit.collider != null)
        {
            return true;
        }

        return false;
    }//IsOnWall
}