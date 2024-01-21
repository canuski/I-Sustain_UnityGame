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
        SceneManager.LoadScene("Game_Over");
    }
}
