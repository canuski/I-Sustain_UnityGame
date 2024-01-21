
using TMPro;
using UnityEngine;

public class ShowLore : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public string textToDisplay = "Dit is mijn tekst!";
    public float displayDuration = 20f;

    void Start()
    {
        displayText.text = textToDisplay;

        Invoke("HideText", displayDuration);
    }

    void HideText()
    {
        displayText.gameObject.SetActive(false);
    }
}
