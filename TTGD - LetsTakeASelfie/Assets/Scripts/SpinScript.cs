using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    private Transform pivotPoint;

    public float spinSpeed = 0;
    public float spinAcceleration = 100;

    private void Start()
    {
        pivotPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        spinSpeed += spinAcceleration * Time.deltaTime;
        pivotPoint.Rotate(-Vector3.forward * spinSpeed * Time.deltaTime);
    }
}
