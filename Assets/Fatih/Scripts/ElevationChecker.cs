using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevationChecker : MonoBehaviour
{
    public float respawnElevation = 90f;
    public string levelToLoad = "Level5";

    void Update()
    {
        if (transform.position.y < 90)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // You can add additional logic here if needed, e.g., play a respawn animation.

        // Reload the current scene or load a specific level.
        SceneManager.LoadScene("Game_Over");
    }
}
