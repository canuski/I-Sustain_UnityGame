using UnityEngine;

public class DamageMohammed : MonoBehaviour
{
    public float damageAmount = 10.0f;

    public bool damageOnTrigger = true;
    public bool damageOnCollision = false;
    public bool continuousDamage = false;
    public float continuousTimeBetweenHits = 0;

    private float savedTime = 0;

    void OnTriggerEnter(Collider collision)
    {
        if (damageOnTrigger)
        {
            DealDamage(collision.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (damageOnCollision)
        {
            DealDamage(collision.gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (continuousDamage)
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<HealthMohammed>() != null)
            {
                if (Time.time - savedTime >= continuousTimeBetweenHits)
                {
                    savedTime = Time.time;
                    DealDamage(collision.gameObject);
                }
            }
        }
    }

    void DealDamage(GameObject target)
    {
        if (target.tag == "Player" && target.GetComponent<HealthMohammed>() != null)
        {
            target.GetComponent<HealthMohammed>().ApplyDamage(damageAmount);
        }
    }
}
