using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndMoveUp : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float moveSpeed = 0.2f;
    public float moveDistance = 0.5f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        float verticalMovement = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = initialPosition + new Vector3(0f, verticalMovement, 0f);
    }
}
