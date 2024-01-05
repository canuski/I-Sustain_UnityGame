using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    private float flyTime = 1f; // Time to fly in one direction
    private float rotateTime = 1f; // Time to rotate 180 degrees
    private float timer = 0f;
    private bool isFlying = true;

    // Reference to the platform (cube) that will act as a limit
    public GameObject platform;

    void Update()
    {
        if (isFlying)
        {
            Fly();
        }
        else
        {
            Rotate180Degrees();
        }
    }

    void Fly()
    {
        // Move forward for the specified fly time
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check for collisions with the platform and adjust position if necessary
        ClampPositionToPlatform();

        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to rotate
        if (timer >= flyTime)
        {
            // Reset timer and switch to rotation state
            timer = 0f;
            isFlying = false;
        }
    }

    void Rotate180Degrees()
    {
        // Rotate 180 degrees over the specified rotation time
        float rotationSpeed = 180f / rotateTime;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to switch back to flying state
        if (timer >= rotateTime)
        {
            // Reset timer and switch to flying state
            timer = 0f;
            isFlying = true;
        }
    }

    void ClampPositionToPlatform()
    {
        // Check for collisions with the platform
        Collider platformCollider = platform.GetComponent<Collider>();
        if (platformCollider.bounds.Intersects(GetComponent<Collider>().bounds))
        {
            // Adjust position to stay on the platform
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, platform.transform.position.x - platform.transform.localScale.x / 2f, platform.transform.position.x + platform.transform.localScale.x / 2f),
                transform.position.y,
                Mathf.Clamp(transform.position.z, platform.transform.position.z - platform.transform.localScale.z / 2f, platform.transform.position.z + platform.transform.localScale.z / 2f)
            );
        }
    }
}
