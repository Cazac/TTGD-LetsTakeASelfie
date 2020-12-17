using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject playerToFollow;


    private int currentCameraNode = -1;


    public List<GameObject> startingCameraNodes_List;
    public List<int> startingCameraSizes_List;






    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (!GameStateManager.Instance.isCameraZooming || !GameStateManager.Instance.isCameraReady))
        {
            GameStateManager.Instance.isCameraZooming = true;
            GameStateManager.Instance.isCameraReady = true;
            GameStateManager.Instance.isGameFullyReady = true;
            gameObject.transform.position = startingCameraNodes_List[startingCameraNodes_List.Count - 1].transform.position;
            Camera.main.orthographicSize = 6f;
            CoolGameTextController.Instance.ShowGoText();
        }

        if (!GameStateManager.Instance.isCameraZooming)
        {
            if (currentCameraNode == -1)
            {
                Camera.main.orthographicSize = GameSettingsController.Instance.cameraIntroSize;
                gameObject.transform.position = startingCameraNodes_List[0].transform.position;
                currentCameraNode++;
            }

            float currentDistance = Vector3.Distance(startingCameraNodes_List[currentCameraNode].transform.position, gameObject.transform.position);
            Vector3 newPosition = Vector3.Lerp(gameObject.transform.position, startingCameraNodes_List[currentCameraNode].transform.position, 0.05f);
      


            //Move Camera
            gameObject.transform.position = newPosition;

            //Check For Next Node
            if (currentDistance < 2.5f)
            {
                currentCameraNode++;
            }

            //Check For Finish
            if (currentCameraNode >= startingCameraNodes_List.Count)
            {
                GameStateManager.Instance.isCameraZooming = true;
            }

            return;
        }

        if (!GameStateManager.Instance.isCameraReady)
        {
            //Scale Times Max Size
            float difference = Camera.main.orthographicSize - 6f;
            float progress = (difference * 0.9f) + 6f;


            //Zoom in the size
            Camera.main.orthographicSize = progress;

            if (Camera.main.orthographicSize <= 6.1f)
            {
                GameStateManager.Instance.isCameraReady = true;
                GameStateManager.Instance.isGameFullyReady = true;
                Camera.main.orthographicSize = 6f;
                CoolGameTextController.Instance.ShowGoText();
            }
        }

        if (playerToFollow != null)
        {
            //float distance = Vector3.Distance(gameObject.transform.position, playerToFollow.transform.position);
            //float ratio = GameSettingsController.Instance.cameraSpeed * Time.deltaTime;
            //ratio = 1f;
            Vector3 newPosition; //= Vector3.Lerp(gameObject.transform.position, playerToFollow.transform.position, ratio);

            //Debug
            newPosition = playerToFollow.transform.position;

            newPosition = new Vector3(newPosition.x, newPosition.y + 3, -1);
            gameObject.transform.position = newPosition;
        }
    }
}
