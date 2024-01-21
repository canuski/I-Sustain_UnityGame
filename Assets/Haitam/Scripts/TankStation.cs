using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankStationSpawner : MonoBehaviour
{
    public GameObject tankStationPrefab;
    public GameObject collectible1Prefab;
    public GameObject collectible2Prefab;
    public GameObject collectible3Prefab;
    private Vector3 tankStationSpawnLocation;

    private bool tankStationSpawned = false;
    private List<GameObject> collectedCollectibles = new List<GameObject>();

    public TextMeshProUGUI collectedText;

    void Start()
    {
        GameObject tankStationSpawnPoint = GameObject.Find("TankStationSpawnPoint");
        if (tankStationSpawnPoint != null)
        {
            tankStationSpawnLocation = tankStationSpawnPoint.transform.position;
        }
        else
        {
            Debug.LogError("TankStationSpawnPoint not found. Make sure it exists in the scene.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!tankStationSpawned && CheckCollectedCollectibles())
            {
                SpawnTankStation();
            }
        }

        // Bijwerken van de tekst op het scherm
        UpdateUIText();
    }

    void SpawnTankStation()
    {
        Instantiate(tankStationPrefab, tankStationSpawnLocation, Quaternion.identity);
        tankStationSpawned = true;
        collectedCollectibles.Clear();
    }

    bool CheckCollectedCollectibles()
    {
        List<GameObject> requiredCollectiblePrefabs = new List<GameObject> { collectible1Prefab, collectible2Prefab, collectible3Prefab };

        foreach (GameObject requiredCollectiblePrefab in requiredCollectiblePrefabs)
        {
            if (!collectedCollectibles.Contains(requiredCollectiblePrefab))
            {
                return false;
            }
        }

        return true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Collect(other.gameObject);
        }
    }

    void Collect(GameObject collectibleGameObject)
    {
        if (!collectedCollectibles.Contains(collectibleGameObject))
        {
            collectedCollectibles.Add(collectibleGameObject);
            Destroy(collectibleGameObject);
        }
    }

    // Functie om de tekst op het scherm bij te werken
    void UpdateUIText()
    {
        // Bijwerken van de tekst met het aantal verzamelde collectibles
        if (collectedText != null)
        {
            collectedText.text = "Collected collectables: " + collectedCollectibles.Count+"\nPress T after you have collected 3 collectables";
        }
    }
}