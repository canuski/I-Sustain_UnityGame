using UnityEngine;
using UnityEngine.UI;

public class ShowRawImageAndPlayAnimation : MonoBehaviour
{
    public Animator objectAnimator;  // Reference to the Animator component
    public RawImage rawImage;        // Reference to the RawImage component

    void Start()
    {
        // Ensure the RawImage is initially hidden
        if (rawImage != null)
        {
            rawImage.enabled = false;
        }
    }

    void Update()
    {
        // Check for user input (for example, pressing the "E" key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the visibility of the RawImage
            ToggleRawImage();

            // Play the animation
            PlayAnimation();
        }
    }

    void ToggleRawImage()
    {
        // Toggle the visibility of the RawImage
        if (rawImage != null)
        {
            rawImage.enabled = !rawImage.enabled;
        }
    }

    void PlayAnimation()
    {
        // Play the animation only if the Animator is present and has a specific trigger
        if (objectAnimator != null && objectAnimator.runtimeAnimatorController != null)
        {
            // Trigger a specific animation state in the Animator
            objectAnimator.SetTrigger("PlayAnimationTrigger");
        }
    }
}
