using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotateAndSwitchOnKeyPress : MonoBehaviour
{
    public GameObject toggleElement; // UI element to toggle with the "E" key
    public GameObject showElement;   // UI element to show when the player is close
    public float closeDistance = 3f; // Distance threshold to consider the player "close"
    public AudioClip activationSound; // Sound played on activation
    private bool isActivated = false;
    // Additional properties
    public Vector3 targetRotation = new Vector3(60f, 0f, 0f);
    public GameObject objectToDestroy;
    public GameObject objectToActivate;
    public string scoreboardTag = "scoreboard"; // Tag of the Canvas Text
    public int targetScore = 40; // Target score to trigger actions

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            // Check if the player is close enough to the object
            if (distance < closeDistance)
            {
                // Show additional UI element when player is close and not activated
                if (!isActivated && showElement != null)
                {
                    showElement.SetActive(true);
                }

                // Check if the "E" key is pressed and the UI is not yet activated
                if (Input.GetKeyDown(KeyCode.E) && !isActivated && CurrentScoreIsEqualToTarget())
                {
                    // Play activation sound
                    if (activationSound != null)
                    {
                        AudioSource.PlayClipAtPoint(activationSound, transform.position);
                    }
                    // Rotate the assigned object in the Z-axis continuously

                    // Set isActivated to true to prevent further activations
                    isActivated = true;

                    // Additional functionality for RotateAndSwitchOnKeyPress
                    ApplyTargetRotation();
                    DeactivateObject();
                    ToggleObjectActivation();

                    // Check scoreboard and trigger actions if the target score is reached
                    StartCoroutine(DisplayToggleElementCoroutine());
                }
            }
            else
            {
                // Player is not close, reset activation state and hide additional UI element
                isActivated = false;

                if (showElement != null)
                {
                    showElement.SetActive(false);
                }
            }
        }
    }

    // Additional methods for RotateAndSwitchOnKeyPress
    void ApplyTargetRotation()
    {
        if (objectToActivate != null)
        {
            transform.rotation = Quaternion.Euler(targetRotation);
        }
    }

    void DeactivateObject()
    {
        if (objectToDestroy != null)
        {
            objectToDestroy.SetActive(false);
        }
    }

    void ToggleObjectActivation()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(!objectToActivate.activeSelf);
        }
    }

    IEnumerator DisplayToggleElementCoroutine()
    {
        // Display the toggle element for 3 seconds
        if (toggleElement != null)
        {
            toggleElement.SetActive(true);
            yield return new WaitForSeconds(3f);
            toggleElement.SetActive(false);
        }

        // Reset activation state after displaying the toggle element
        isActivated = false;
    }

    bool CurrentScoreIsEqualToTarget()
    {
        if (!string.IsNullOrEmpty(scoreboardTag))
        {
            GameObject scoreboardObject = GameObject.FindGameObjectWithTag(scoreboardTag);
            if (scoreboardObject != null)
            {
                Text textComponent = scoreboardObject.GetComponent<Text>();
                if (textComponent != null)
                {
                    int currentScore;
                    if (int.TryParse(textComponent.text, out currentScore))
                    {
                        return currentScore >= targetScore;
                    }
                    else
                    {
                        Debug.LogWarning("Failed to parse the current score from the Canvas Text with tag '" + scoreboardTag + "'.");
                    }
                }
                else
                {
                    Debug.LogWarning("Text component not found on Canvas Text with tag '" + scoreboardTag + "'.");
                }
            }
            else
            {
                Debug.LogWarning("Canvas Text with tag '" + scoreboardTag + "' not found.");
            }
        }
        else
        {
            Debug.LogWarning("Scoreboard tag not assigned to RotateAndSwitchOnKeyPress script during score check.");
        }

        return false;
    }
}
