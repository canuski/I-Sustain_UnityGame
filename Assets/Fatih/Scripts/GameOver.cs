using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Level_5");
    }
    public void ExitButton() 
    {
        SceneManager.LoadScene("Menu");
    }
}
