using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoProController : MonoBehaviour
{

    public GameObject GoProHand;

    public PlayerMovement playerMovement;


    private void Update()
    {
        if (GameSettingsController.Instance.isGoProUsingMouse)
        {
            MoveCameraByMouse();
        }
        else
        {
            //Player Input To Move Camera
            MoveCameraByInput();

            //Move Camera By Gravity
            MoveCameraByBalence();

            //Move the Player With The Camera
            MovePlayerByGoProPostion();
        }

        
        //selfie Mode safe check
        if (playerMovement == null)
        {
            return;
        }

        if (GameSettingsController.Instance.isGoProAffectingSpeed)
        {

            Vector3 currentRotation = GoProHand.transform.rotation.eulerAngles;

            //Forwards
            if (currentRotation.z >= 180)
            {
                //How Close to 270??
                float mag = Mathf.Abs(currentRotation.z - 290);
                mag = 1 - (mag / 90);

                //print("Test Code: Magnitude Forwards " + mag);

                if (playerMovement.gameObject.transform.GetChild(0).localRotation.eulerAngles.y == 0)
                {
                    playerMovement.speedMultiplier = (1.6f * mag) + 1f;
                }
                else if (playerMovement.gameObject.transform.GetChild(0).localRotation.eulerAngles.y == 180)
                {
                    playerMovement.speedMultiplier = (0f * mag) + 1f;
                }
            }
            //Back
            else
            {
                //How Close to 90??
                float mag = Mathf.Abs(currentRotation.z - 70);
                mag = 1 - (mag / 90);

                //print("Test Code: Magnitude Back " + mag);

                if (playerMovement.gameObject.transform.GetChild(0).localRotation.eulerAngles.y == 0)
                {
                    playerMovement.speedMultiplier = (0f * mag) + 1f;
                }
                else if (playerMovement.gameObject.transform.GetChild(0).localRotation.eulerAngles.y == 180)
                {
                    playerMovement.speedMultiplier = (1.6f * mag) + 1f;
                }
            }
        }
        else
        {
            playerMovement.speedMultiplier = 0;
        }
    }

    ///////////////////////////////////////////////////////

    private void MoveCameraByInput()
    {
        if (GameSettingsController.Instance.isGoProUsingMomentum)
        {
            print("Test Code: Nope");
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Move Camrea Right
                GoProHand.transform.Rotate(new Vector3(0f, 0f, -GameSettingsController.Instance.goProRotationSpeed * Time.deltaTime), Space.Self);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Move Camrea Left
                GoProHand.transform.Rotate(new Vector3(0f, 0, GameSettingsController.Instance.goProRotationSpeed * Time.deltaTime), Space.Self);
            }
        }
    }

    private void MoveCameraByBalence()
    {
        if (GameSettingsController.Instance.isGoProUsingBalence)
        {
            Vector3 currentRotation;


   

            currentRotation = GoProHand.transform.rotation.eulerAngles;


            if (currentRotation.z >= 180)
            {
                //How Close to 270??
                //float mag = Mathf.Abs(currentRotation.z - 270);
                //mag = 1 - (mag / 90);

                //print("Test Code: Magnitude " + mag);


                //Move Camrea Right
                GoProHand.transform.Rotate(new Vector3(0f, 0, (-GameSettingsController.Instance.goProMomentumSpeed) * Time.deltaTime), Space.Self);
            }
            else
            {
                //How Close to 90??
                //float mag = Mathf.Abs(currentRotation.z - 90);
                //mag = 1 - (mag / 90);



                //print("Test Code: Magnitude " + mag);



                //Move Camrea Left
                GoProHand.transform.Rotate(new Vector3(0f, 0, (GameSettingsController.Instance.goProMomentumSpeed) * Time.deltaTime), Space.Self);
            }
        }
    }

    private void MovePlayerByGoProPostion()
    {
        if (GameSettingsController.Instance.isGoProAffectingSpeed)
        {
            Vector3 currentRotation;




            currentRotation = GoProHand.transform.rotation.eulerAngles;


            if (currentRotation.z >= 180)
            {
                //How Close to 270??
                float mag = Mathf.Abs(currentRotation.z - 290);
                mag = 1 - (mag / 90);

                //print("Test Code: Magnitude " + mag);
            }
            else
            {
                //How Close to 90??
                float mag = Mathf.Abs(currentRotation.z - 70);
                mag = 1 - (mag / 90);



                //print("Test Code: Magnitude " + mag);
            }
        }
    }

    private void MoveCameraByMouse()
    {
        Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 handVector = new Vector2(GoProHand.transform.position.x, GoProHand.transform.position.y);




        float angle = Vector2.Angle(handVector, mousePostion);

        angle = AngleInDeg(handVector, mousePostion);
        angle -= 90;

        GoProHand.transform.eulerAngles = new Vector3(0, 0, angle);
        //GoProHand.transform.eulerAngles = new Vector3(0, 0, Vector2.Angle(worldPosition, GoProHand.transform.position));
    }



    //This returns the angle in radians
    public static float AngleInRad(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
    }

    //This returns the angle in degrees
    public static float AngleInDeg(Vector3 vec1, Vector3 vec2)
    {
        return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
    }

    ///////////////////////////////////////////////////////
}