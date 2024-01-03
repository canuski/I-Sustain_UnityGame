using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        // Rotate the object
        RotateObject();
    }

    void RotateObject()
    {
        // Get input axis for rotation
        float rotationInput = Input.GetAxis("Horizontal");

        // Rotate the object around its own up axis (Y-axis) based on input
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }
}