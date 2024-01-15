using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeX : MonoBehaviour
{
    // Define the rotation speed
    public float rotationSpeed = 5f;

    // Reference to the GameObject that triggers rotation
    public GameObject activationObject;

    // Boolean flag to check if rotation is allowed
    private bool allowRotation = false;

    void Update()
    {
        // Check if the activationObject is active
        if (activationObject != null && activationObject.activeSelf)
        {
            allowRotation = true;
        }

        // Check if rotation is allowed
        if (allowRotation)
        {
            // Rotate the object only around the Z-axis
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }
}