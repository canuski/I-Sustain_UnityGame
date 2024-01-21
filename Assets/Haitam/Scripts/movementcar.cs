
using UnityEngine;

public class movementcar : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Beweeg het voertuig vooruit/achteruit
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        // Draai het voertuig
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
    }

}
