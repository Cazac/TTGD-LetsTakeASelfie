using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxMovement : MonoBehaviour
{

    [Header("Speeds")]
    [Range(0, 1f)]
    public float paralaxSpeedRatio_X;
    [Range(0, 1f)]
    public float paralaxSpeedRatio_Y;


    private Transform cameraTransform;
    private Vector3 lastCameraPostion;




    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPostion = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 delaMovement = cameraTransform.position - lastCameraPostion;
        transform.position += new Vector3(delaMovement.x * paralaxSpeedRatio_X, delaMovement.y * paralaxSpeedRatio_Y);
        lastCameraPostion = cameraTransform.position;
    }

}
