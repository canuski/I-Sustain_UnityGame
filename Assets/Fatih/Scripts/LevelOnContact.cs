using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Credits");
    }
}