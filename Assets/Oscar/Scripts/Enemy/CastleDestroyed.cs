using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleHealth : MonoBehaviour
{
    //iinvoervelden voor de veschillende objecten
    [SerializeField] GameObject NextScene;
    [SerializeField] float healthPoints = 1f;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float particleSystemDuration = 2f;
    [SerializeField] AudioClip destroySound;

    private AudioSource destroyAudioSource;

    void Start()
    {
        // maak een nieuwe game object of geluid te behandelen
        GameObject audioSourceObject = new GameObject("DestroyAudioSource");
        destroyAudioSource = audioSourceObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        //wordt gechekt als de health minder of 0 is
        if (healthPoints <= 0)
        {
            HandleDeath();
        }
    }

    public void ApplyDamage(float amount)
    {
        //hier wordt de damage aangebracht
        healthPoints -= amount;
        if (healthPoints <= 0)
        {
            //als de heathpoints minder als 0 zijn hier al dood aanroepen, niet noodzakelijk denk ik
            HandleDeath();
        }
    }

    void HandleDeath()
    {
        //er moet een explosie prefab zijn toegewezen 
        if (explosionPrefab != null)
        {
            // de explosie intansiaten, het gaat een explosie instance maken, daarna de positie van het
            //huidige object nemen om daar te instantiaten, en laast de default rotatie nemen (geen extra rotatie)
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // haal de particlesystem van de explosioin, die is aangemaakt met een particle system
            ParticleSystem particleSystem = explosion.GetComponent<ParticleSystem>();

            // stop de particles na een bepaalde tijd
            StopParticleSystemAfterDuration(particleSystem, particleSystemDuration);

            // sound afspelen
            PlayDestroySound();

            // panel voor next scene aan zetten
            NextScene.SetActive(true);

            // het game object (kasteel) destroyen
            Destroy(gameObject);
        }
    }

    void StopParticleSystemAfterDuration(ParticleSystem particleSystem, float duration)
    {
        //er moet een particle system zijn
        if (particleSystem != null)
        {
            // .Stop() wordt aangeroepen en daarna wordt het detroyed          
            particleSystem.Stop();
            Destroy(particleSystem.gameObject, duration);
        }
    }

    public void MoveToNextScene()
    {
        // ga naar de scene die 1 buildindex naar boven is (volgende level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    void PlayDestroySound()
    {
        // sound afspelen, er moeten een paar componenten aanwezig zijn
        if (destroyAudioSource != null && destroySound != null)
        {
            // playoneshot omdat het een heel kort geluid is, geen nood aan .pause en .stop
            destroyAudioSource.PlayOneShot(destroySound);
        }
    }
}
