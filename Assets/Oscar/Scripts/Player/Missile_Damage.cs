using UnityEngine;

public class MissileDamage : MonoBehaviour
{
    public float damageAmount = 10.0f; // damage instellen

    void OnTriggerEnter(Collider other)
    {
        //  check als object collide met enemy tag
        if (other.CompareTag("Enemy"))
        {
            // enemy health en castle healh component halen
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            CastleHealth castleHealth = other.GetComponent<CastleHealth>();

            // als de enemnyhealth er is of de castle helath dan damage doen bij hen
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

            // missile detroyen
            Destroy(gameObject);
        }
    }
}
