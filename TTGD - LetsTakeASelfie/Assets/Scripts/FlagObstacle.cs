using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagObstacle : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            WinnerController.Instance.Winner();
        }
    }



    private void BoostPlayer()
    {

    }

}
