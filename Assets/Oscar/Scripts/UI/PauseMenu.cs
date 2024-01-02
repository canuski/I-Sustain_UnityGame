using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; //om game te pauzeren
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;// 1f doet het terug naar normale tijd
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
