using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawningSystem : MonoBehaviour
{
    public Transform spawnset;
    public GameObject Prefab;

    List<GameObject> EnemyList;

    void Start()
    {
        SpawnEnemies(spawnset);
        EnemyList = new List<GameObject>();
    }
    public void SpawnEnemies(Transform Spawnset)
    {
        foreach (Transform child in Spawnset)
        {
            var newenemy = Instantiate(Prefab, child.position, Quaternion.identity);
            EnemyList.Add(newenemy);
        }
    }
    void Update() 
    {

        if(EnemyList.Count <= 0 && SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

            
    }
}
