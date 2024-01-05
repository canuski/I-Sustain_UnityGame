using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController2 : MonoBehaviour
{
    // Reference to the canvas with the "player_data" tag
    public Canvas playerDataCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // Initially, disable the canvas
        playerDataCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "P" key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle the visibility of the canvas
            playerDataCanvas.enabled = !playerDataCanvas.enabled;
        }
    }
}
