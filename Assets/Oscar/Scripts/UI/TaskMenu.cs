using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject LorePage;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //laad de volgende scene in de queue kan ook met naam maar di t is beter
        //ga naar file/build settings om je scene toe te voegen aan de queue
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //laad de vorige scene in de queue kan ook met naam maar di t is beter
        //ga naar file/build settings om je scene toe te voegen aan de queue
    }
    public void Lore()
    {
        Menu.SetActive(false);
        LorePage.SetActive(true);
    }
    public void BackToMenu()
    {
        LorePage.SetActive(false);
        Menu.SetActive(true);
    }
}
