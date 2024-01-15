using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas4:MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        // Check for Escape button press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        // Toggle the pause menu
        if (pauseMenu != null)
        {
            bool isPaused = pauseMenu.activeSelf;
            pauseMenu.SetActive(!isPaused);

            // Adjust Time.timeScale based on pause state
            Time.timeScale = isPaused ? 1 : 0;
        }
    }
}