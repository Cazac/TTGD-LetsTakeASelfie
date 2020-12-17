using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeperController : MonoBehaviour
{

    public TextMeshProUGUI score_Text;
    public TextMeshProUGUI time_Text;

    [SerializeField]
    private Rigidbody2D rb;

    private float currentTime = 0;
    private float currentScore = 0;
    public float scoreMulti = 10;

    // Update is called once per frame
    private void Update()
    {
        if (GameStateManager.Instance.isGameFullyReady)
        {
            currentTime += Time.deltaTime;

            currentScore += (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) * Time.deltaTime * scoreMulti;
        }

        time_Text.text = "Stream Time: " + Mathf.Round(currentTime);
        score_Text.text = "Followers!: " + (int)currentScore;
    }
}