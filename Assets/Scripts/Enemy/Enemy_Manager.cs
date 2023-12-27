using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] int aantalEnemyOpAxis = 10;
    [SerializeField] int gridSpacing = 100;

    void Start()
    {
        PlaceEnemy();
    }

    void PlaceEnemy()
    {
        for (int x = 0; x < aantalEnemyOpAxis; x++)
        {
            for (int y = 0; y < aantalEnemyOpAxis; y++)
            {
                for (int z = 0; z < aantalEnemyOpAxis; z++)
                {
                    InstantiateEnemy(x, y, z);
                }
            }
        }
    }
    void InstantiateEnemy(int x, int y, int z)
    {
        Instantiate(enemy,
            new Vector3(transform.position.x + (x * gridSpacing) + EnemyOffset(),
                        transform.position.y + (y * gridSpacing) + EnemyOffset(),
                        transform.position.z + (z * gridSpacing) + EnemyOffset()),
                        Quaternion.identity,
                        transform);
    }
    float EnemyOffset()
    {
        return Random.Range(gridSpacing / 2f, gridSpacing / 2f);
    }
}