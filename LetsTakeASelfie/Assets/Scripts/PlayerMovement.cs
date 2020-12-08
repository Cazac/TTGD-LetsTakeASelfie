using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;




    private Rigidbody2D rb2d;
    private BoxCollider2D boxcollider2d;




    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxcollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = 0;
        float jump = 0;

        //right
        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1;
        }

        //left
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded() == true)
            {
                jump = GameSettingsController.Instance.playerJumpHeight;
            }
        }

        Vector2 movement = new Vector2(moveHorizontal, jump);

        rb2d.AddForce(movement * GameSettingsController.Instance.playerSpeed);

    }//Update

    private bool IsGrounded()
    {
        float extraColliderTest = 0.1f;

        RaycastHit2D raycastHit = Physics2D.Raycast(boxcollider2d.bounds.center, Vector2.down, boxcollider2d.bounds.extents.y + extraColliderTest, platformLayerMask);
        if (raycastHit.collider != null)
        {
            return true;
        }

        raycastHit = Physics2D.Raycast(boxcollider2d.bounds.center, Vector2.right, boxcollider2d.bounds.extents.x + extraColliderTest, platformLayerMask);
        if (raycastHit.collider != null)
        {
            return true;
        }

        raycastHit = Physics2D.Raycast(boxcollider2d.bounds.center, Vector2.right, -(boxcollider2d.bounds.extents.x + extraColliderTest), platformLayerMask);
        if (raycastHit.collider != null)
        {
            return true;
        }

        return false;

    }//IsGrounded
}