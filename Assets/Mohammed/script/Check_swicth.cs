using UnityEngine;
using UnityEngine.UI;

public class CheckScoreboard : StateMachineBehaviour
{
    public string scoreboardTag = "Scoreboard"; // Tag of the Canvas Text
    public int targetScore = 40; // Target score to trigger animation
    public AnimationClip animationClip; // Animation clip to play on reaching the target score

    private int initialScore; // Initial score of the Canvas Text

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if the scoreboardTag is assigned
        if (!string.IsNullOrEmpty(scoreboardTag))
        {
            // Find the Canvas Text with the specified tag
            GameObject scoreboardObject = GameObject.FindGameObjectWithTag(scoreboardTag);
            if (scoreboardObject != null)
            {
                // Get the initial score from the text component
                Text textComponent = scoreboardObject.GetComponent<Text>();
                if (textComponent != null)
                {
                    if (int.TryParse(textComponent.text, out initialScore))
                    {
                        // Initial score successfully parsed
                    }
                    else
                    {
                        Debug.LogWarning("Failed to parse initial score from the Canvas Text with tag '" + scoreboardTag + "'.");
                    }
                }
                else
                {
                    Debug.LogWarning("Text component not found on Canvas Text with tag '" + scoreboardTag + "'.");
                }
            }
            else
            {
                Debug.LogWarning("Canvas Text with tag '" + scoreboardTag + "' not found.");
            }
        }
        else
        {
            Debug.LogWarning("Scoreboard tag not assigned to CheckScoreboard script.");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if the scoreboardTag is assigned
        if (!string.IsNullOrEmpty(scoreboardTag))
        {
            // Find the Canvas Text with the specified tag
            GameObject scoreboardObject = GameObject.FindGameObjectWithTag(scoreboardTag);
            if (scoreboardObject != null)
            {
                // Get the current score from the text component
                Text textComponent = scoreboardObject.GetComponent<Text>();
                if (textComponent != null)
                {
                    int currentScore;
                    if (int.TryParse(textComponent.text, out currentScore))
                    {
                        // Check if the score has reached the target
                        if (currentScore >= targetScore && initialScore < targetScore)
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
                    else
                    {
                        Debug.LogWarning("Failed to parse current score from the Canvas Text with tag '" + scoreboardTag + "'.");
                    }
                }
                else
                {
                    Debug.LogWarning("Text component not found on Canvas Text with tag '" + scoreboardTag + "'.");
                }
            }
            else
            {
                Debug.LogWarning("Canvas Text with tag '" + scoreboardTag + "' not found during score check.");
            }
        }
        else
        {
            Debug.LogWarning("Scoreboard tag not assigned to CheckScoreboard script during score check.");
        }
    }
}
