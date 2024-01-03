using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    public float healthPoints = 10f;
    public float respawnHealthPoints = 10f;
    public bool isAlive = true;
    public GameObject explosionPrefab;
    public DeathAction onDeath = DeathAction.DoNothingWhenDead;
    public Transform teleportDestination;
    public Text currentHealthText; // Reference to the Canvas text for current health
    public GameObject deathStarImage; // Reference to the Canvas image for DeathStar

    public enum DeathAction { TeleportToDestination, DoNothingWhenDead }

    private bool canMove = true; // Flag to control player movement

    void Start()
    {
        // Find the Canvas text using the tag
        GameObject canvasTextObject = GameObject.FindGameObjectWithTag("CurrentHP");

        // Check if the Canvas text object exists and has the Text component
        if (canvasTextObject != null)
        {
            currentHealthText = canvasTextObject.GetComponent<Text>();
            UpdateCurrentHealthText(); // Update the Canvas text with initial health
        }

        // Assign the DeathStar image directly
        deathStarImage = GameObject.Find("DeathStar");

        // Check if the DeathStar object exists and has the GameObject component
        if (deathStarImage != null)
        {
            deathStarImage.SetActive(true); // Make sure the DeathStar image is initially active
        }
    }

    void Update()
    {
        if (healthPoints <= 0 && isAlive)
        {
            isAlive = false;
            Debug.Log("Player Died. Initiating explosion.");

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                StartCoroutine(DelayedTeleport()); // Start the coroutine for delayed teleportation
            }

            if (onDeath == DeathAction.TeleportToDestination && teleportDestination != null)
            {
                Debug.Log("Teleporting to: " + teleportDestination.position);
                DestroyDeathStarImage(); // Destroy the DeathStar image when teleporting
            }
        }

        // Update the Canvas text with current health
        UpdateCurrentHealthText();
    }

    IEnumerator DelayedTeleport()
    {
        canMove = false; // Disable player movement

        yield return new WaitForSeconds(0.3f); // Wait for 1 second

        if (teleportDestination != null)
        {
            TeleportToDestination();
            Debug.Log("Teleporting to: " + teleportDestination.position);
        }

        canMove = true; // Enable player movement after teleportation
    }

    public void ApplyDamage(float amount)
    {
        if (canMove)
        {
            healthPoints -= amount;
            UpdateCurrentHealthText(); // Update the Canvas text when health changes
        }
    }

    public void ApplyHeal(float amount)
    {
        if (canMove)
        {
            healthPoints += amount;
            healthPoints = Mathf.Min(healthPoints, respawnHealthPoints);
            UpdateCurrentHealthText(); // Update the Canvas text when health changes
        }
    }

    private void TeleportToDestination()
    {
        transform.position = teleportDestination.position;
        healthPoints = respawnHealthPoints;
        isAlive = true;

        // Update the Canvas text after teleporting
        UpdateCurrentHealthText();
    }

    private void UpdateCurrentHealthText()
    {
        // Check if the reference to the Canvas text exists
        if (currentHealthText != null)
        {
            // Update the text with current health
            currentHealthText.text = healthPoints.ToString();
        }
    }

    private void DestroyDeathStarImage()
    {
        // Check if the reference to the DeathStar image exists
        if (deathStarImage != null)
        {
            // Destroy the DeathStar image
            Destroy(deathStarImage);
        }
    }
}
