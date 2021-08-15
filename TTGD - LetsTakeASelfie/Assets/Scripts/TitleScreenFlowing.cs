using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenFlowing : MonoBehaviour
{
    public float BGSpeed = 0;


    private void Update()
    {
        Vector3 speed = new Vector3(BGSpeed, 0f, 0f);
        gameObject.transform.position += speed * Time.deltaTime;
    }
}
