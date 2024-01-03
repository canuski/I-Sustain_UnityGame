using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmUp : StateMachineBehaviour
{
    public AnimationClip animationClip; // Animation clip to play on 'E' key press
    public KeyCode activationKey = KeyCode.E; // Key to activate the animation

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if the activation key is pressed
        if (Input.GetKeyDown(activationKey))
        {
            // Trigger the animation
            if (animationClip != null)
            {
                animator.Play(animationClip.name);
            }
            else
            {
                Debug.LogWarning("Animation clip not assigned to CheckScoreboard script.");
            }
        }
    }
}
