using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoProController : MonoBehaviour
{

    public GameObject GoProHand;




    private void Update()
    {
        //Player Input To Move Camera
        MoveCameraByInput();

        //Move Camera By Gravity
        MoveCameraByBalence();

        //Move the Player With The Camera
        MovePlayerByGoProPostion();











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
                float mag = Mathf.Abs(currentRotation.z - 270);
                mag = 1 - (mag / 90);

                print("Test Code: Magnitude " + mag);


                //Move Camrea Right
                GoProHand.transform.Rotate(new Vector3(0f, 0, (-GameSettingsController.Instance.goProMomentumSpeed) * Time.deltaTime), Space.Self);
            }
            else
            {
                //How Close to 90??
                float mag = Mathf.Abs(currentRotation.z - 90);
                mag = 1 - (mag / 90);



                print("Test Code: Magnitude " + mag);



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
                float mag = Mathf.Abs(currentRotation.z - 270);
                mag = 1 - (mag / 90);

                print("Test Code: Magnitude " + mag);
            }
            else
            {
                //How Close to 90??
                float mag = Mathf.Abs(currentRotation.z - 90);
                mag = 1 - (mag / 90);



                print("Test Code: Magnitude " + mag);
            }
        }
    }


    ///////////////////////////////////////////////////////
}
