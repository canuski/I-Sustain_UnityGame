using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(AudioSource))]
public class Rocket_shoot : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;
    public float missileForce = 10f;
    public float missileLightDuration = 10f;
    public float fireCooldown = 1f;
    public float missileLifetime = 3f;

    [SerializeField] private AudioClip rocketLaunchSound;

    private Light missileLight;
    private AudioSource audioSource;
    private bool canFire = true;

    private void Awake()
    {
        missileLight = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey("space") && canFire)
        {
            FireMissile();
        }
    }

    void FireMissile()
    {
        canFire = false;
        StartCoroutine(ResetFireCooldown());

        GameObject missile = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation);
        Rigidbody missileRigidbody = missile.GetComponent<Rigidbody>();
        missileRigidbody.AddForce(missileSpawnPoint.forward * missileForce, ForceMode.Impulse);

        missileLight.enabled = true;

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rocketLaunchSound);
        }

        StartCoroutine(TurnOffMissileLight());
        StartCoroutine(DestroyMissile(missile));
    }

    IEnumerator TurnOffMissileLight()
    {
        yield return new WaitForSeconds(missileLightDuration);
        missileLight.enabled = false;
    }
    IEnumerator DestroyMissile(GameObject missile)
    {
        yield return new WaitForSeconds(missileLifetime);
        Destroy(missile);
    }
    IEnumerator ResetFireCooldown()
    {
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }
}
