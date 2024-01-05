using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTextAndSwitch : MonoBehaviour
{
    // Reference to the UI Text with the tag "Destroyed_cars"
    private Text destroyedCarsText;

    // Game objects to be destroyed and activated
    public GameObject objectToDestroy;
    public GameObject objectToActivate;

    void Start()
    {
        // Find the UI Text with the tag "Destroyed_cars"
        destroyedCarsText = GameObject.FindGameObjectWithTag("Destroyed_cars")?.GetComponent<Text>();

        if (destroyedCarsText == null)
        {
            Debug.LogError("UI Text with tag 'Destroyed_cars' not found!");
        }
    }

    void Update()
    {
        // Check if the UI Text exists
        if (destroyedCarsText != null)
        {
            // Parse the text to an integer
            if (int.TryParse(destroyedCarsText.text, out int destroyedCarsCount))
            {
                // Check if the count reaches 11
                if (destroyedCarsCount >= 40)
                {
                    // Destroy the specified game object
                    DestroyObject();

                    // Activate the specified game object
                    ActivateObject();
                }
            }
            else
            {
                Debug.LogError("Failed to parse the text to an integer.");
            }
        }
    }

    void DestroyObject()
    {
        // Check if the object to destroy is not null
        if (objectToDestroy != null)
        {
            // Destroy the specified game object
            Destroy(objectToDestroy);
        }
    }

    void ActivateObject()
    {
        // Check if the object to activate is not null
        if (objectToActivate != null)
        {
            // Activate the specified game object
            objectToActivate.SetActive(true);
        }
    }
}
