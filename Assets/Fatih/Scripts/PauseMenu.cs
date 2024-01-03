using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    private AudioSource backgroundMusicAudioSource;

    void Start()
    {
        backgroundMusicAudioSource = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        backgroundMusicAudioSource.UnPause();
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        backgroundMusicAudioSource.Pause();

        PlayerPrefs.SetInt("musicPaused", 1);
        PlayerPrefs.Save();
    }

    public void LoadMenu() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitMenu()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }


}
