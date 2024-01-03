using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disappear2 : MonoBehaviour
{
    public float closeDistance = 3f; // Distance threshold to consider the player "close"

    private bool playerInRange = false;
    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        // Check if the player is in range and pressed the 'E' key
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isActivated)
        {
            Destroy(gameObject);

            // Find the GameObject with the "Destroyed_cars" tag
            GameObject scoreboard = GameObject.FindGameObjectWithTag("Destroyed_cars");

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

            // Set isActivated to true to prevent further activations
            isActivated = true;
        }
    }
}
