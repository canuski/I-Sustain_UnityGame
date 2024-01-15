using UnityEngine;
using UnityEngine.UI;

public class CheckScoreboard : StateMachineBehaviour
{
    public string scoreboardTag = "scoreboard"; // Tag of the Canvas Text
    public int targetScore = 40; // Target score to trigger animation
    public AnimationClip animationClip; // Animation clip to play on reaching the target score

    private int initialScore = -1; // Initial score of the Canvas Text, initialized to an invalid value

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Attempt to retrieve the initial score
        if (TryGetInitialScore())
        {
            // Successfully retrieved the initial score
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Attempt to check the current score and trigger animation if needed
        TryCheckScoreAndTriggerAnimation(animator, stateInfo, layerIndex);
    }

    // Function to try to get the initial score from the Canvas Text
    private bool TryGetInitialScore()
    {
        // Check if the scoreboardTag is assigned
        if (string.IsNullOrEmpty(scoreboardTag))
        {
            Debug.LogWarning("Scoreboard tag not assigned to CheckScoreboard script.");
            return false;
        }

        // Find the Canvas Text with the specified tag
        GameObject scoreboardObject = GameObject.FindGameObjectWithTag(scoreboardTag);

        if (scoreboardObject == null)
        {
            Debug.LogWarning("Canvas Text with tag '" + scoreboardTag + "' not found.");
            return false;
        }

        // Get the initial score from the text component
        Text textComponent = scoreboardObject.GetComponent<Text>();

        if (textComponent == null)
        {
            Debug.LogWarning("Text component not found on Canvas Text with tag '" + scoreboardTag + "'.");
            return false;
        }

        if (!int.TryParse(textComponent.text, out initialScore))
        {
            Debug.LogWarning("Failed to parse initial score from the Canvas Text with tag '" + scoreboardTag + "'.");
            return false;
        }

        return true;
    }

    // Function to check the current score and trigger animation if needed
    private void TryCheckScoreAndTriggerAnimation(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if the scoreboardTag is assigned
        if (string.IsNullOrEmpty(scoreboardTag))
        {
            Debug.LogWarning("Scoreboard tag not assigned to CheckScoreboard script during score check.");
            return;
        }

        // Find the Canvas Text with the specified tag
        GameObject scoreboardObject = GameObject.FindGameObjectWithTag(scoreboardTag);

        if (scoreboardObject == null)
        {
            Debug.LogWarning("Canvas Text with tag '" + scoreboardTag + "' not found during score check.");
            return;
        }

        // Get the current score from the text component
        Text textComponent = scoreboardObject.GetComponent<Text>();

        if (textComponent == null)
        {
            Debug.LogWarning("Text component not found on Canvas Text with tag '" + scoreboardTag + "'.");
            return;
        }

        int currentScore;

        if (!int.TryParse(textComponent.text, out currentScore))
        {
            Debug.LogWarning("Failed to parse current score from the Canvas Text with tag '" + scoreboardTag + "'.");
            return;
        }

        // Check if the score has reached the target
        if (currentScore >= targetScore && initialScore < targetScore)
        {
            // Trigger the animation
            if (animationClip != null)
            {
                animator.Play(stateInfo.fullPathHash, layerIndex, 0f);
            }
            else
            {
                Debug.LogWarning("Animation clip not assigned to CheckScoreboard script.");
            }
        }
    }
}
