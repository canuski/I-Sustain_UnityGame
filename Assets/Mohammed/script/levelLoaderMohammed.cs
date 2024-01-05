using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoaderMohammed : MonoBehaviour
{
    public float playerProximityThreshold = 5f;
    public GameObject popupObject; // Reference to the GameObject that will appear

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (popupObject != null)
        {
            popupObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the player is near the object
        if (IsPlayerNearObject() && !popupObject.activeSelf)
        {
            // Show the popup object when the player is near
            popupObject.SetActive(true);
        }
    }

    bool IsPlayerNearObject()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            return distance <= playerProximityThreshold;
        }

        return false;
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    public void RepeatLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if the next build index is within bounds
        if (nextBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextBuildIndex);
        }
        else
        {
            Debug.LogWarning("No next level available. You may want to handle this case differently.");
        }
    }
}
