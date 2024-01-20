using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject questionText;
    public Collider triggerCollider;

    void Start()
    {
        questionText.SetActive(false);
    }

    void Update()
    {
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            questionText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            questionText.SetActive(false);
        }
    }

    void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Oscar_level2");
    }
}
