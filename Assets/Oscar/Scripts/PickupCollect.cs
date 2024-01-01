using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PickupCollect : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] GameObject popUpPlane; // Assign the reference in the Unity Editor
    [SerializeField] GameObject NextTask; 
    private static int scoreValue = 0;
    private int barrelsToCollectToShowPopUp = 3;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreValue = 0;
        SetScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player Ship"))
        {
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();

            if (scoreValue >= barrelsToCollectToShowPopUp)
            {
                // Check if we've collected enough barrels to show the pop-up
                ShowPopUp();
            }
        }
    }

    void SetScore()
    {
        score.text = "Garbage collected: " + scoreValue;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void ShowPopUp()
    {
        // Activate the pop-up plane
        if (popUpPlane != null)
        {
            popUpPlane.SetActive(true);
        }
    }
    public void NextTasks()
    {
        popUpPlane.SetActive(false);
        NextTask.SetActive(true);
    }
    public void SaveTheDay()
    {
        NextTask.SetActive(false);
    }


}
