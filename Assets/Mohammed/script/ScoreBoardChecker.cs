using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardChecker : MonoBehaviour
{
    public string scoreboardTag = "scoreboard";
    public GameObject objectToMove;
    public float yOffset = 40f;

    void Update()
    {
        // Find all GameObjects with the specified tag
        GameObject[] scoreboards = GameObject.FindGameObjectsWithTag(scoreboardTag);

        // Assuming you want to check the first GameObject found with the tag
        if (scoreboards.Length > 0)
        {
            // Get the Text component of the scoreboard GameObject
            Text scoreboardText = scoreboards[0].GetComponent<Text>();

            if (scoreboardText != null)
            {
                // Parse the text value to an integer
                if (int.TryParse(scoreboardText.text, out int scoreValue))
                {
                    // Check if the score is exactly 16
                    if (scoreValue == 16)
                    {
                        // Increase the y-position of the specified object
                        Vector3 newPosition = objectToMove.transform.position;
                        newPosition.y += yOffset;
                        objectToMove.transform.position = newPosition;
                    }
                }
                else
                {
                    Debug.LogError("Failed to parse scoreboard text as an integer.");
                }
            }
            else
            {
                Debug.LogError("Scoreboard GameObject does not have a Text component.");
            }
        }
    }
}
