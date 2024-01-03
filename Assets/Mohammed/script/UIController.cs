using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Transform playerTransform;
    public string buttonTag = "Press_E"; // The tag of the button
    public float visibilityDistance = 5f; // Adjust this distance as needed
    public GameObject uiElement;

    private bool isVisible = false;

    void Start()
    {
        // Make the UI element initially invisible
        uiElement.SetActive(false);
    }

    void Update()
    {
        // Find the button with the specified tag
        GameObject button = GameObject.FindGameObjectWithTag(buttonTag);

        // Check if the button is found
        if (button != null)
        {
            // Check the distance between the player and the button
            float distance = Vector3.Distance(playerTransform.position, button.transform.position);

            // Update the visibility state of the UI element based on the distance
            bool shouldBeVisible = distance <= visibilityDistance;

            // If the visibility state has changed, update the UI element
            if (isVisible != shouldBeVisible)
            {
                uiElement.SetActive(shouldBeVisible);
                isVisible = shouldBeVisible;
            }
        }
        else
        {
            Debug.LogWarning("Button with tag " + buttonTag + " not found.");
        }
    }
}
