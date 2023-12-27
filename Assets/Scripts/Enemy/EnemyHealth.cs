using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float healthPoints = 1f;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float particleSystemDuration = 2f;
    [SerializeField] AudioClip destroySound;

    private AudioSource destroyAudioSource;

    void Start()
    {
        // Create a new GameObject to handle destroy sound separately
        GameObject audioSourceObject = new GameObject("DestroyAudioSource");
        destroyAudioSource = audioSourceObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (healthPoints <= 0)
        {
            HandleDeath();
        }
    }

    public void ApplyDamage(float amount)
    {
        healthPoints -= amount;
        if (healthPoints <= 0)
        {
            HandleDeath();
        }
    }

    void HandleDeath()
    {
        if (explosionPrefab != null)
        {
            // Instantiate the explosion prefab
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Get the Particle System component from the explosion prefab
            ParticleSystem particleSystem = explosion.GetComponent<ParticleSystem>();

            // Stop emitting particles after the specified duration
            StopParticleSystemAfterDuration(particleSystem, particleSystemDuration);

            // Play destroy sound
            PlayDestroySound();

            // Destroy the enemy object immediately
            Destroy(gameObject);
        }
    }

    void StopParticleSystemAfterDuration(ParticleSystem particleSystem, float duration)
    {
        if (particleSystem != null)
        {
            // Stop emitting particles after the specified duration
            particleSystem.Stop();
            Destroy(particleSystem.gameObject, duration);
        }
    }

    void PlayDestroySound()
    {
        if (destroyAudioSource != null && destroySound != null)
        {
            destroyAudioSource.PlayOneShot(destroySound);
        }
    }
}
