using System.Collections;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject truckPrefab;
    public float objectSpeed = 10f;
    public float spawnInterval = 5f;
    public float truckSpawnDelay = 2f; // Adjust the delay for truck spawning
    public Transform endPoint;
    public Transform spawnPoint; // Use a common spawn point

    void Start()
    {
        StartCoroutine(SpawnVehicles());
    }

    IEnumerator SpawnVehicles()
    {
        while (true)
        {
            // Example: Spawn a car at a specific position facing 180 degrees
            SpawnVehicle(carPrefab);

            yield return new WaitForSeconds(truckSpawnDelay); // Add a delay before spawning the truck

            // Example: Spawn a truck at another specific position facing 180 degrees
            SpawnVehicle(truckPrefab);

            yield return new WaitForSeconds(spawnInterval - truckSpawnDelay); // Adjust the delay for the next iteration
        }
    }

    void SpawnVehicle(GameObject prefab)
    {
        Quaternion spawnRotation = Quaternion.Euler(0f, 180f, 0f);
        GameObject spawnedObject = Instantiate(prefab, spawnPoint.position, spawnRotation);
        StartCoroutine(MoveObject(spawnedObject.transform));
    }

    IEnumerator MoveObject(Transform objectTransform)
    {
        while (objectTransform.position.z > endPoint.position.z)
        {
            // Move the object in the forward direction (regardless of its rotation)
            objectTransform.Translate(Vector3.forward * objectSpeed * Time.deltaTime);

            yield return null;
        }

        Destroy(objectTransform.gameObject);
    }
}
