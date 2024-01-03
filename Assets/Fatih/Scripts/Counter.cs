using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text score;
    private static int scoreValue = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject collectible = gameObject; // Assuming the collectible is the GameObject with the Counter script
            Destroy(collectible); // Or you can disable it as needed
            scoreValue += 1;
            SetScore();

            // Access the TimerController script and call CollectCollectible method
            Timer timerController = other.GetComponent<Timer>();
            if (timerController != null)
            {
                timerController.CollectCollectible(collectible);
                Debug.Log("CollectCollectible called from Counter! Score: " + scoreValue);
            }
        }
    }

    void SetScore()
    {
        score.text = $"{scoreValue}";
    }
}
