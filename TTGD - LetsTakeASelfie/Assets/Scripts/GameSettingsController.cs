using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsController : MonoBehaviour
{
    ///////////////////////////////////////////////////////

    public static GameSettingsController Instance;

    ///////////////////////////////////////////////////////

    [Header("Player Options")]
    public float playerSpeed;
    public float playerJumpHeight;
    public float playerGravity;

    [Header("GoPro Options")]
    public float goProRotationSpeed;
    public float goProMomentumSpeed;
    public bool isGoProUsingMomentum;
    public bool isGoProUsingMouse;
    public bool isGoProAffectingSpeed;
    public bool isGoProUsingBalence;
    public bool isGoProAccelerationOnly;

    [Header("Camera Options")]
    public float cameraIntroSize;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        Instance = this;
    }

    ///////////////////////////////////////////////////////
}
