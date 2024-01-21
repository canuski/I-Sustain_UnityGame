using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float initialTime = 30f;
    private float currentTime;
    private bool isTimerRunning = true;

    public Text timerText;
    public string collectibleTag = "Collectible";

    void Start()
    {
        currentTime = initialTime;
        UpdateTimerText();
        InvokeRepeating("UpdateTimer", 1f, 1f); // invoke method repeatedly with 1 sec delay
    }

    void UpdateTimer() // checks wether time is up or not
    {
        if (isTimerRunning)
        {
            currentTime -= 1f;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isTimerRunning = false;

                Debug.Log("Game Over!");
                SceneManager.LoadScene("Game_Over");
            }

            UpdateTimerText(); // keep displaying all the changes
        }
    }

    void UpdateTimerText() // logic to update timer in my desired format
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = "Time: " + formattedTime;
        }
    }

    public void CollectCollectible(GameObject collectible)
    {
        currentTime += 20f; // wehn collectible is collected +20sec
        UpdateTimerText();

        if (collectible != null)
        {
            collectible.SetActive(false); // make collectible dissapear
            Debug.Log("Collectible collected! Current Time: " + currentTime);
        }
    }
}
