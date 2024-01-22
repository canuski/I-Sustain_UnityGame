using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // instelling
    [SerializeField] float healthPoints = 1f;
    [SerializeField] int numberOfLives = 1;

    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject playerModel;

    void Update()
    {
        // death handelen a;s health onder 
        if (healthPoints <= 0 && numberOfLives > 0)
        {
            HandleDeath();
        }
    }

    public void ApplyDamage(float amount)
    {
        // als player nog leeft
        if (IsAlive())
        {
            // zelfde logica als andere health scripts
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
            // de explosie intansiaten, het gaat een explosie instance maken, daarna de positie van het
            //huidige object nemen om daar te instantiaten, en laast de default rotatie nemen (geen extra rotatie)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        numberOfLives--;

        Respawn(); 
        Die();
     
    }

    void Respawn()
    {
        // scene loaden
        SceneManager.LoadScene("Level2");
    }

    void Die()
    {
        // wanneer alle levens weg zijn
        Destroy(gameObject);
    }


    bool IsAlive()
    {
        return numberOfLives > 0;
    }
}
