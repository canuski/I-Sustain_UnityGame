using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{
    public Text score;
    private static int scoreValue = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
        }
    }
    void SetScore()
    {
        score.text = $"{scoreValue}";
    }
}