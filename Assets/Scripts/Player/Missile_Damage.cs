using UnityEngine;

public class MissileDamage : MonoBehaviour
{
    public float damageAmount = 10.0f;

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            CastleHealth castleHealth = other.GetComponent<CastleHealth>();

            if (enemyHealth != null || castleHealth != null)
            {
                if (enemyHealth != null)
                {
                    enemyHealth.ApplyDamage(damageAmount);
                }
                else if (castleHealth != null)
                {
                    castleHealth.ApplyDamage(damageAmount);
                }
            }

            // Destroy the missile
            Destroy(gameObject);
        }
    }
}
