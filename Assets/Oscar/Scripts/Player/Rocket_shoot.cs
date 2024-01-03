using System.Collections;
using UnityEngine;


public class Rocket_shoot : MonoBehaviour
{
    // publieke variabelen instellen

    [SerializeField] GameObject missilePrefab;
    [SerializeField] Transform missileSpawnPoint;
    [SerializeField] float missileForce = 10f;
    [SerializeField] float missileLightDuration = 10f;
    [SerializeField] float fireCooldown = 1f;
    [SerializeField] float missileLifetime = 3f;

    [SerializeField] private AudioClip rocketLaunchSound;

    // licht component aan de gameobject
    private Light missileLight;
    // audio component aan de gameobject
    private AudioSource audioSource;
    // boolean om aan te geven als raket kan schieten
    private bool canFire = true;

    // Awake wordt geroepen als de instance wordt geladen (kan ook in start)
    private void Awake()
    {
        // licht en audio initializeren
        missileLight = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // als spatie balk is ingedrukt en canFire is true dan schiet
        if (Input.GetKey("space") && canFire)
        {
            FireMissile();
        }
    }

    void FireMissile()
    {
        // op false zetten zodat er niet rapid fire gebeurd
        canFire = false;
        // de fire cooldown starten zodat canFire terug op true komt
        StartCoroutine(ResetFireCooldown());

        // missile aanmaken met de gespecifeerde attributen
        GameObject missile = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation);
        // haalt de rigidbody en voegt een voorwaardse force toe met de gegeven snelheid(moet heel hoog zijn)
        // ForceMode.Impulse is een optie bij physics zodat het opject
        Rigidbody missileRigidbody = missile.GetComponent<Rigidbody>();
        missileRigidbody.AddForce(missileSpawnPoint.forward * missileForce, ForceMode.Impulse);

        // zet het licht aan van de missile
        missileLight.enabled = true;

        // enkel als er momenteel niks wordt afgespeeld maak het geluid
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rocketLaunchSound);
        }

        // functies om na een bepaalde tijd licht uit te zetten en de missile te destroyen
        StartCoroutine(TurnOffMissileLight());
        StartCoroutine(DestroyMissile(missile));
    }

    // manier om na een tijd iets uit te voeren in unity
    // info op https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
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
