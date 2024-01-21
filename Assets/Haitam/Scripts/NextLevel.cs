using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject questionText;
    private bool playerInTrigger = false;

    void Start()
    {
        Debug.Log("Script is running.");
        questionText.SetActive(false);
    }

    void Update()
    {
        Debug.Log("Update method is called.");

        if (playerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("Y key pressed. LoadNextLevel called.");
                LoadNextLevel();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("N key pressed. Question text set to inactive.");
                questionText.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("Player entered the trigger.");
            questionText.SetActive(true);
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("Player exited the trigger.");
            questionText.SetActive(false);
            playerInTrigger = false;
        }
    }

    void LoadNextLevel()
    {
        Debug.Log("Loading next level.");

        // Zoek het huidige niveau in de build settings
        Scene currentScene = SceneManager.GetActiveScene();
        int currentBuildIndex = currentScene.buildIndex;

        // Ga naar het volgende niveau in de build settings
        int nextBuildIndex = (currentBuildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextBuildIndex);
    }
}