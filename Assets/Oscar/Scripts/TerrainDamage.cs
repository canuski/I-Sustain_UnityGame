using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount = 10.0f;
    public bool damageOnTrigger = true;
    public bool damageOnCollision = false;
    public bool continuousDamage = false;
    public float continuousTimeBetweenHits = 0;
    public bool destroySelfOnImpact = false;
    public float delayBeforeDestroy = 0.0f;
    public GameObject explosionPrefab;

    private float savedTime = 0;

    void OnTriggerEnter(Collider other)
    {
        if (damageOnTrigger && other.CompareTag("Player Ship"))
        {
            ApplyDamage(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (damageOnCollision && collision.gameObject.CompareTag("PlayerShip"))
        {
            ApplyDamage(collision.gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (continuousDamage && collision.gameObject.CompareTag("PlayerShip"))
        {
            if (Time.time - savedTime >= continuousTimeBetweenHits)
            {
                savedTime = Time.time;
                ApplyDamage(collision.gameObject);
            }
        }
    }

    void ApplyDamage(GameObject target)
    {
        if (target.GetComponent<Health>() != null)
        {
            target.GetComponent<Health>().ApplyDamage(damageAmount);

            if (destroySelfOnImpact)
            {
                Destroy(gameObject, delayBeforeDestroy);
            }

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
        }
    }
}
