using UnityEngine;
using UnityEngine.UI;

public class NumberAudioPlayer : MonoBehaviour
{
    public Text canvasText;
    public AudioClip audioClip;

    private int previousNumber;

    void Start()
    {
        if (canvasText == null || audioClip == null)
        {
            Debug.LogError("Please assign the required components in the inspector.");
            return;
        }

        // Assuming the initial value is a valid number
        if (int.TryParse(canvasText.text, out previousNumber))
        {
            // You may want to handle the case where the initial value is not a number
        }
    }

    void Update()
    {
        // Check if the text represents a valid number
        if (int.TryParse(canvasText.text, out int currentNumber))
        {
            // Check if the number has increased
            if (currentNumber > previousNumber)
            {
                // Play the audio fragment
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                // Update the previous number
                previousNumber = currentNumber;
            }
        }
        else
        {
            Debug.LogError("Text does not represent a valid number.");
        }
    }
}
