using System.Collections;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject truckPrefab;
    public Transform spawnPointsParent;
    public float vehicleSpeed = 10f;
    public float spawnInterval = 5f;
    public float truckSpawnDelay = 1f; // 1f delay dus 1 sec
    private Transform[] spawnPoints;
    public Transform endPoint;

    void Start()
    {
        // Verzamel alle spawnpunten onder het "SpawnPoints" GameObject
        spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();

        StartCoroutine(SpawnVehicles());
    }

    IEnumerator SpawnVehicles()
    {
        while (true)
        {
            SpawnCar();
            yield return new WaitForSeconds(truckSpawnDelay); // Kleine delay voor dat nieuwe spawnt
            SpawnTruck();
            yield return new WaitForSeconds(spawnInterval - truckSpawnDelay); // kleine delay voor de volgende iteratie
        }
    }

    void SpawnCar()
    {
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;

        GameObject car = Instantiate(carPrefab, spawnPosition, Quaternion.identity);
        StartCoroutine(MoveVehicle(car.transform));
    }

    void SpawnTruck()
    {
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;

        GameObject truck = Instantiate(truckPrefab, spawnPosition, Quaternion.identity);
        StartCoroutine(MoveVehicle(truck.transform));
    }

    IEnumerator MoveVehicle(Transform vehicleTransform)
    {
        while (vehicleTransform.position.z < endPoint.position.z)
        {
            vehicleTransform.Translate(Vector3.forward * vehicleSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(vehicleTransform.gameObject);
    }
}
