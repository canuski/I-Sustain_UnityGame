using UnityEngine;

public class TankStationSpawner : MonoBehaviour
{
    // Voeg het tankstation-prefab toe vanuit de Unity-editor
    public GameObject tankStationPrefab;

    // Update is called once per frame
    void Update()
    {
        // Controleer of de spatiebalk wordt ingedrukt
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Roep de functie aan om een tankstation te spawnen op de huidige positie
            SpawnTankStation();
        }
    }

    // Functie om een tankstation te spawnen op de huidige positie
    void SpawnTankStation()
    {
        // Verkrijg de huidige positie van het script
        Vector3 spawnPosition = transform.position;

        // Spawn het tankstation op de gewenste positie
        Instantiate(tankStationPrefab, spawnPosition, Quaternion.identity);
    }
}
