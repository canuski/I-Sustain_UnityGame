using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PickupCollect : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] GameObject popUpPlane;
    [SerializeField] GameObject NextTask; 
    private static int scoreValue = 0;
    // voor pop up
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

            // om pop up te tonen
            if (scoreValue >= barrelsToCollectToShowPopUp)
            {
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
        if (popUpPlane != null)
        {
            popUpPlane.SetActive(true);
        }
    }
    public void NextTasks()
    {
        // voor next task button
        popUpPlane.SetActive(false);
        NextTask.SetActive(true);
    }
    public void SaveTheDay()
    {
        NextTask.SetActive(false);
    }


}
