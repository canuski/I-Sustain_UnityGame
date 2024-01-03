using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    // Public GameObject to represent the teleport destination
    public GameObject teleportDestination;

    // Check for player entering the teleporter trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.transform);
        }
    }

    // Function to teleport the player to the destination
    private void TeleportPlayer(Transform playerTransform)
    {
        if (teleportDestination != null)
        {
            playerTransform.position = teleportDestination.transform.position;
        }
        else
        {
            Debug.LogError("Teleport destination is not set. Assign a GameObject to the 'teleportDestination' field.");
        }
    }
}
