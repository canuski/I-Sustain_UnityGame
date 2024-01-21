using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text score;
    private static int scoreValue = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if other collider has "Player" tag
        {
            GameObject collectible = gameObject; // collectible = object script is attached to
            Destroy(collectible);
            scoreValue += 1; // update score after destroying
            SetScore();

            // Access the TimerController script and call CollectCollectible method
            Timer timerController = other.GetComponent<Timer>();
            if (timerController != null)
            {
                timerController.CollectCollectible(collectible); // calls this method only if the timercontroller exists
                Debug.Log("Score: " + scoreValue);
            }
        }
    }

    void SetScore()
    {
        score.text = $"{scoreValue}/10";
    }
}
