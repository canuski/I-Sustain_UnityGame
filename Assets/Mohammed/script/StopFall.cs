using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFall : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        _rigidbody = GetComponent<Rigidbody>();

        // Check if Rigidbody component exists
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody component not found on GameObject: " + gameObject.name);
        }
        else
        {
            // Freeze rotation on all axes to prevent falling over
            _rigidbody.freezeRotation = true;
        }
    }
}

