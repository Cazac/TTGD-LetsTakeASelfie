using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    ///////////////////////////////////////////////////////

    public static GameStateManager Instance;

    ///////////////////////////////////////////////////////


    public bool isCameraZooming = false;
    public bool isCameraReady = false;

    public bool isGameFullyReady = false;
    public bool isTimerRunning = true;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        Instance = this;
    }

    ///////////////////////////////////////////////////////
}
