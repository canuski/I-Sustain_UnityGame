using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float healthPoints = 1f;
    public int numberOfLives = 1;

    public GameObject explosionPrefab;
    public GameObject playerModel;

    void Update()
    {
        if (healthPoints <= 0 && numberOfLives > 0)
        {
            HandleDeath();
        }
    }

    public void ApplyDamage(float amount)
    {
        if (IsAlive())
        {
            healthPoints -= amount;
            if (healthPoints <= 0)
            {
                HandleDeath();
            }
        }
    }

    void HandleDeath()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        if (playerModel != null)
        {
            playerModel.SetActive(false);
        }

        numberOfLives--;

        Respawn();
        
        
       
        Die();
     
    }

    void Respawn()
    {
        SceneManager.LoadScene("Scene-1");
    }

    void Die()
    {
        // Handle death when all lives are gone
        Destroy(gameObject);
    }

    public void ApplyHeal(float amount)
    {
        healthPoints = Mathf.Min(healthPoints + amount, 1f); // Assuming 1 is the maximum health
    }

    public void ApplyBonusLife(int amount)
    {
        numberOfLives += amount;
    }

    bool IsAlive()
    {
        return numberOfLives > 0;
    }
}
