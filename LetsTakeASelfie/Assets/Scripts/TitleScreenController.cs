using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MonoBehaviour
{
    ///////////////////////////////////////////////////////


    public static TitleScreenController Instance;


    ///////////////////////////////////////////////////////

    private void Awake()
    {
        Instance = this;
    }

    ///////////////////////////////////////////////////////
    
    public void Button_Main_Play()
    {

    }

    public void Button_Main_Credits()
    {

    }

    public void Button_Main_Quit()
    {
        //Quit
        Application.Quit();
    }

    ///////////////////////////////////////////////////////
    
    public void Button_Play_Back()
    {

    }

    public void Button_Play_LevelSelect(int levelChoice)
    {

    }

    ///////////////////////////////////////////////////////
}
