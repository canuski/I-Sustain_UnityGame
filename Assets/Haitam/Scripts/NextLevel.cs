using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject questionText;
    void Start()
    {
        
        questionText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            questionText.SetActive(true);
        }

        if (questionText.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                LoadNextLevel();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                questionText.SetActive(false);
            }
        }
    }

    void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
