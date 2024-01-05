using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderOscar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Ship"))
        {
            LoadLevel();
        }
    }

    private void LoadLevel()
    {
        // Assuming Level2 is the name of your next scene
        SceneManager.LoadScene("Scene-1");
    }
}
