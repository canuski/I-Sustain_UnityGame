using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        _animator = GetComponent<Animator>();

        // Check if Animator component exists
        if (_animator == null)
        {
            Debug.LogError("Animator component not found on GameObject: " + gameObject.name);
        }
    }

    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Play the animation
            PlayAnimation();
        }
    }

    void PlayAnimation()
    {
        // Check if the Animator component is not null
        if (_animator != null)
        {
            // Trigger the animation named "YourAnimationName"
            _animator.SetTrigger("YourAnimationName");
        }
    }
}
