using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float initialTime = 30f;
    private float currentTime;
    private bool isTimerRunning = true;

    public Text timerText;
    public string collectibleTag = "Collectible"; // Set this to the tag you've assigned to collectibles

    void Start()
    {
        currentTime = initialTime;
        UpdateTimerText();
        InvokeRepeating("UpdateTimer", 1f, 1f);
    }

    void UpdateTimer()
    {
        if (isTimerRunning)
        {
            currentTime -= 1f;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isTimerRunning = false;

                Debug.Log("Game Over! Reloading the scene...");
                SceneManager.LoadScene("Game_Over");
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
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
        currentTime += 20f;
        UpdateTimerText();

        if (collectible != null)
        {
            collectible.SetActive(false);
            Debug.Log("Collectible collected! Timer updated. Current Time: " + currentTime);
        }
    }
}
