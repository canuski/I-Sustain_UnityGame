using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public GameObject targetObject; // The GameObject with the Animator component
    public string animationTrigger = "StartAnimation"; // The trigger parameter name in the Animator

    // Update is called once per frame
    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the targetObject has an Animator component
            Animator targetAnimator = targetObject.GetComponent<Animator>();
            if (targetAnimator != null)
            {
                // Trigger the animation in the targetObject's Animator
                targetAnimator.SetTrigger(animationTrigger);
            }
            else
            {
                Debug.LogWarning("Target object does not have an Animator component.");
            }
        }
    }
}
