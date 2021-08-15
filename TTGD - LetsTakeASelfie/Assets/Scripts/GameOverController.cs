using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    ///////////////////////////////////////////////////////
   
    public static GameOverController Instance;

    public GameObject gameOverUI_Panel;
    public TextMeshProUGUI reasonForBan_Text;

    private bool isGameOverActive = false;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (isGameOverActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                Time.timeScale = 1;
            }
        }
    }

    ///////////////////////////////////////////////////////

    public void Button_Title(string reason)
    {
        Time.timeScale = 1;

        //Title
        SceneManager.LoadScene("Title Screen");
    }

    public void Button_Quit()
    {
        //Quit
        Application.Quit();
    }

    ///////////////////////////////////////////////////////

    public void Death(string reason)
    {
        isGameOverActive = true;

        Time.timeScale = 0;

        //Activate UI
        gameOverUI_Panel.SetActive(true);

        //Set Reason
        //reasonForBan_Text.text = "Reason For Ban: " + reason;


        //Disable Movement ?

        //Disable Sound ?


    }



    ///////////////////////////////////////////////////////
}
