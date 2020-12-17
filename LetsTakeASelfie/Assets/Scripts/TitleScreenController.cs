using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    ///////////////////////////////////////////////////////


    public static TitleScreenController Instance;


    public GameObject mainScreenUI_GO;
    public GameObject playScreenUI_GO;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        Instance = this;
    }

    ///////////////////////////////////////////////////////
    
    public void Button_Main_Play()
    {
        mainScreenUI_GO.SetActive(false);
        playScreenUI_GO.SetActive(true);
    }

    public void Button_Main_Credits()
    {
        //Credits
        SceneManager.LoadScene("Credits");
    }

    public void Button_Main_Quit()
    {
        //Quit
        Application.Quit();
    }

    ///////////////////////////////////////////////////////
    
    public void Button_Play_Back()
    {
        mainScreenUI_GO.SetActive(true);
        playScreenUI_GO.SetActive(false);
    }

    public void Button_Play_LevelSelect(string levelChoice)
    {
        //SceneManager.LoadScene("Programming - Zac");
        SceneManager.LoadScene("Level " + levelChoice);
    }

    ///////////////////////////////////////////////////////
}
