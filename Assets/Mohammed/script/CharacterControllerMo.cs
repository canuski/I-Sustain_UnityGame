using UnityEngine;

public class CharacterControllerMo : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    internal bool isGrounded;

    void Update()
    {
        // Move the character
        MoveCharacter();

        // Rotate the character based on mouse input
        RotateCharacter();
    }

    void MoveCharacter()
    {
        // Get input axes for movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);

        // Move the character based on the input
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void RotateCharacter()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the player horizontally based on mouse input
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);

        // Remove the vertical rotation based on mouse input
        // Commented out the following lines to disable vertical rotation
        /*
        float mouseY = Input.GetAxis("Mouse Y");
        Camera.main.transform.Rotate(Vector3.left, mouseY * rotationSpeed);

        // Clamp the vertical rotation of the camera to avoid flipping
        Vector3 currentRotation = Camera.main.transform.localRotation.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(currentRotation);
        */
    }
}