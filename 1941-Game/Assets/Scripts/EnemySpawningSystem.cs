using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningSystem : MonoBehaviour
{
    public Transform spawnset;
    public GameObject Prefab;

    void Start()
    {
        SpawnEnemies(spawnset);
    }
    public void SpawnEnemies(Transform Spawnset)
    {
        foreach (Transform child in Spawnset)
        {
            var newenemy = Instantiate(Prefab, child.position, Quaternion.identity);
        }
    }
}
