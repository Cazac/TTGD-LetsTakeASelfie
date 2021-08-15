using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoProCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 8)
        {
            GameOverController.Instance.Death("Broken Camera :(");
        }
    }

}
