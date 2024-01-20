using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject questionText;
    public BoxCollider triggerCollider;

    private bool playerInTrigger = false;
    private bool collisionOccurred = false;

    void Start()
    {
        Debug.Log("Script is running.");
        questionText.SetActive(false);
    }

    void Update()
    {
        Debug.Log("Update method is called.");

        if (playerInTrigger && collisionOccurred)
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
        if (other.CompareTag("Player") && !collisionOccurred)
        {
            Debug.Log("Player entered the trigger.");
            questionText.SetActive(true);
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && playerInTrigger)
        {
            Debug.Log("Player exited the trigger.");
            questionText.SetActive(false);
            playerInTrigger = false;
        }
    }

    void LoadNextLevel()
    {
        Debug.Log("Loading next level.");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Oscar_level2");
    }
}
