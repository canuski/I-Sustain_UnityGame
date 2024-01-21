using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour
{
    public Text legacyTextBox;
    public float displayDuration = 5f;
    public string displayText = "Your Specified Text";

    void Start()
    {
    }

    void OnTriggerEnter(Collider other) // method gets called when collider enters trigger zone of object script is attached to
    {
        if (other.CompareTag("Player")) 
        {
            legacyTextBox.text = displayText;
            Time.timeScale = 0f; // pause the game
            _ = DelayAndDestroyTextAsync(); // call async method '_' is used for ignoring result
        }
    }

    async Task DelayAndDestroyTextAsync() // async method that will wait certain duration before executing
    {
        await Task.Delay((int)(displayDuration * 1000)); // Convert seconds to milliseconds
        DestroyText();
    }

    void DestroyText()
    {
        Debug.Log("Destroying text");
        Destroy(legacyTextBox.gameObject);
        Time.timeScale = 1f;
    }
}
