using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectsAndModify : MonoBehaviour
{
    public GameObject objectToCheck1;
    public GameObject objectToCheck2;
    public GameObject growingObject;
    public GameObject objectToDestroy;

    void Update()
    {
        // Check if both objects are active
        if (objectToCheck1.activeSelf && objectToCheck2.activeSelf)
        {
            // Grow the third object
            GrowObject();

            // Destroy the fourth object
            DestroyObject();
        }
    }

    void GrowObject()
    {
        // Check if the growing object is not null
        if (growingObject != null)
        {
            // Set the scale of the growing object to (2, 2, 2)
            growingObject.transform.localScale = new Vector3(5f, 5f, 5f);
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
}

