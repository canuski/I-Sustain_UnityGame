using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject toggleElement;
    public GameObject showElement;
    public float closeDistance = 3f;
    public AudioClip activationSound;
    public float volumeMultiplier = 5.0f;

    private bool isActivated = false;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance < closeDistance)
            {
                if (!isActivated && showElement != null)
                {
                    showElement.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E) && !isActivated)
                {
                    if (activationSound != null)
                    {
                        // Create an AudioSource to play the AudioClip
                        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

                        // Adjust the volume of the AudioSource
                        audioSource.volume = volumeMultiplier;

                        // Play the AudioClip using the AudioSource
                        audioSource.PlayOneShot(activationSound);

                        // Destroy the AudioSource component after playing the sound
                        Destroy(audioSource, activationSound.length);
                    }

                    if (toggleElement != null)
                    {
                        toggleElement.SetActive(!toggleElement.activeSelf);
                        Invoke("HideToggleElement", 3f);
                    }

                    isActivated = true;
                }
            }
            else
            {
                isActivated = false;

                if (showElement != null)
                {
                    showElement.SetActive(false);
                }
            }
        }
    }

    void HideToggleElement()
    {
        if (toggleElement != null)
        {
            toggleElement.SetActive(false);
        }
    }
}
