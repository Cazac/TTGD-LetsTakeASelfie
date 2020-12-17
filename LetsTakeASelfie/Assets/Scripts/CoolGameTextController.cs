using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolGameTextController : MonoBehaviour
{
    ///////////////////////////////////////////////////////

    public static CoolGameTextController Instance;

    ///////////////////////////////////////////////////////

    public Animator GoText_Anim;
    public Animator CountdownText_Anim;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        Instance = this;
    }

    public void ShowGoText()
    {
        GoText_Anim.Play("Go Text Fade");
    }

    public void ShowCountdownText()
    {
        GoText_Anim.Play("Go Text Fade");
    }

    //public IEnumerator Countdown()
    //{
        //yield return new  ;
    //}

    ///////////////////////////////////////////////////////
}
