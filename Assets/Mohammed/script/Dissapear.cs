using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Disappear : MonoBehaviour
{
    public AudioClip destructionSound; // Audio clip for destruction sound
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component on the current GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource component is not found
        if (audioSource == null)
        {
            // Add an AudioSource component if not present
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the AudioClip for the AudioSource
        audioSource.clip = destructionSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Play the destruction sound
            if (audioSource != null && destructionSound != null)
            {
                audioSource.Play();
            }

            Destroy(gameObject);

            // Find the GameObject with the "scoreboard" tag
            GameObject scoreboard = GameObject.FindGameObjectWithTag("scoreboard");

            // Check if the scoreboard GameObject is not null
            if (scoreboard != null)
            {
                // Get the Text component from the scoreboard GameObject
                Text scoreText = scoreboard.GetComponent<Text>();

                // Check if the Text component is not null
                if (scoreText != null)
                {
                    // Try to parse the current score as an integer
                    if (int.TryParse(scoreText.text, out int currentScore))
                    {
                        // Assuming your score is an integer value, you can increase it here
                        currentScore++;

                        // Update the Text component with the new score value
                        scoreText.text = currentScore.ToString();
                    }
                    else
                    {
                        Debug.LogError("Unable to parse score as an integer.");
                    }
                }
                else
                {
                    Debug.LogError("Text component not found on the scoreboard GameObject.");
                }
            }
            else
            {
                Debug.LogError("Scoreboard GameObject not found.");
            }
        }
    }
}
