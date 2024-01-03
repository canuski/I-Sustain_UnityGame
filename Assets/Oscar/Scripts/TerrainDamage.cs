using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damageAmount = 10.0f;
    [SerializeField] GameObject explosionPrefab;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Ship"))
        {
            ApplyDamage(other.gameObject);
        }
    }


    void ApplyDamage(GameObject target)
    {
        if (target.GetComponent<Health>() != null)
        {
            target.GetComponent<Health>().ApplyDamage(damageAmount);
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
        }
    }
}
