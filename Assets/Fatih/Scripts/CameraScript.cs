using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X"); // retrieves horizontal movement of mouse and assigns to yaw value
        pitch -= speedV * Input.GetAxis("Mouse Y"); // retrieves vertical movement of mouse and assigns to pitch value

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); // update camera's rotation (x,y,z)
    }
}
