using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimmyAnimationControls : MonoBehaviour
{
    ///////////////////////////////////////////////////////

    public static JimmyAnimationControls Instance;

    ///////////////////////////////////////////////////////

    public PlayerMovement playerMovement_Script;



    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        SetJimmyRotation();
        SetJimmyAnimationCycle();
    }

    private void SetJimmyRotation()
    {
        if (playerMovement_Script.gameObject.GetComponent<Rigidbody2D>().velocity.x > 1.5)
        {
            playerMovement_Script.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (playerMovement_Script.gameObject.GetComponent<Rigidbody2D>().velocity.x< -1.5)
        {
            playerMovement_Script.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void SetJimmyAnimationCycle()
    {
        playerMovement_Script.gameObject.GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(playerMovement_Script.gameObject.GetComponent<Rigidbody2D>().velocity.x));


        bool doubleTrouble;

        if (playerMovement_Script.IsOnWallRight() || playerMovement_Script.IsOnWallLeft())
        {
            doubleTrouble = true;
        }
        else
        {
            doubleTrouble = false;
        }
            
        playerMovement_Script.gameObject.GetComponent<Animator>().SetBool("IsGrounded", playerMovement_Script.IsGrounded());
        playerMovement_Script.gameObject.GetComponent<Animator>().SetBool("IsWalled", doubleTrouble);

    }

    public void SetJumpSquat()
    {
        playerMovement_Script.gameObject.GetComponent<Animator>().Play("Squating Jimmy");
    }

    public void SetLiftOff()
    {
        //playerMovement_Script.gameObject.GetComponent<Animator>().Play("Liftoff Jimmy");
    }
}
