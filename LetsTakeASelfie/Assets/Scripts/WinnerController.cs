using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerController : MonoBehaviour
{
    ///////////////////////////////////////////////////////

    public static WinnerController Instance;

    ///////////////////////////////////////////////////////

    public GameObject winner_Panel;

    public GameObject playerReal_GO;
    public GameObject playerSelfie_GO;

    public GameObject hidingObjectCircle_GO;
    public GameObject hidingObjectText_GO;


    ///////////////////////////////////////////////////////

    private void Awake()
    {
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void Button_Title(string reason)
    {
        //Title
        SceneManager.LoadScene("Title Screen");
    }

    public void Button_Restart()
    {
        Time.timeScale = 1;

        //Restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    ///////////////////////////////////////////////////////

    public void Winner()
    {
        GameStateManager.Instance.isTimerRunning = false;
        GameStateManager.Instance.isGameFullyReady = false;

        playerReal_GO.SetActive(false);
        playerSelfie_GO.SetActive(true);

        hidingObjectCircle_GO.SetActive(false);
        hidingObjectText_GO.SetActive(false);

        //Activate UI
        winner_Panel.SetActive(true);

        //Set Camera
        Camera.main.transform.position = playerSelfie_GO.transform.position;

        //Time.timeScale = 0;
    }

    ///////////////////////////////////////////////////////
}
