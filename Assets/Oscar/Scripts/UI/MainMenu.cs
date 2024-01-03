using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //laad de volgende scene in de queue kan ook met naam maar di t is beter
        //ga naar file/build settings om je scene toe te voegen aan de queue
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
