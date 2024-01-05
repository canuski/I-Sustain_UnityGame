using System.Collections;
using UnityEngine;

public class ToxicWaste : MonoBehaviour
{
    public GameObject toxicBarrelPrefab;

    void Start()
    {
        // Start the coroutine for spawning toxic barrels
        StartCoroutine(SpawnToxicBarrel());
    }

    IEnumerator SpawnToxicBarrel()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); // Wait for 3 seconds before spawning a new barrel

            // Spawn the toxic barrel at the current location
            GameObject toxicBarrel = Instantiate(toxicBarrelPrefab, transform.position, Quaternion.identity);

            // Add Rigidbody component if it doesn't exist
            if (!toxicBarrel.GetComponent<Rigidbody>())
            {
                toxicBarrel.AddComponent<Rigidbody>();
            }

            // Add Collider component if it doesn't exist
            if (!toxicBarrel.GetComponent<Collider>())
            {
                toxicBarrel.AddComponent<BoxCollider>();
            }

            // Let the barrel fall into the water
            StartCoroutine(FallIntoWater(toxicBarrel));
        }
    }

    IEnumerator FallIntoWater(GameObject toxicBarrel)
    {
        Rigidbody rb = toxicBarrel.GetComponent<Rigidbody>();

        // Assuming the water surface is at y-coordinate 0
        while (toxicBarrel.transform.position.y > 0)
        {
            rb.AddForce(Vector3.down * 10f, ForceMode.Acceleration);
            yield return null;
        }
    }
}
