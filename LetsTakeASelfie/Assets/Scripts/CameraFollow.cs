using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject playerToFollow;



    private void Update()
    {
        if (playerToFollow != null)
        {

            float distance = Vector3.Distance(gameObject.transform.position, playerToFollow.transform.position);


            Vector3 newPosition = Vector3.Lerp(gameObject.transform.position, playerToFollow.transform.position, GameSettingsController.Instance.cameraSpeed);

            newPosition = new Vector3(newPosition.x, newPosition.y, -1);

            gameObject.transform.position = newPosition;

            //print("Test Code: " + distance);
        }
    }
}
