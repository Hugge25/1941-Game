using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawningSystem : MonoBehaviour
{
    public Transform spawnset;
    public GameObject Prefab;

    public GameObject tempenemy;

    //[SerializeField]
    public List<GameObject> EnemyList = new List<GameObject>();
    void Start()
    {
     //   EnemyList = new List<GameObject>();
        SpawnEnemies(spawnset);
    }
    public void SpawnEnemies(Transform Spawnset)
    {
        foreach (Transform child in Spawnset)
        {
            var newenemy = Instantiate(Prefab, child.position, Quaternion.identity);
            newenemy.GetComponent<Enemy>().enemyspawingsystem = this;
            //tempenemy = newenemy;
            EnemyList.Add(newenemy);
        }
    }
    void Update() 
    {
        for(int i = 0; i < EnemyList.Count - 1; i++)
        {
            if(EnemyList[i] == null)
            {
                EnemyList.RemoveAt(i);
            }

        }
        if(EnemyList.Count <= 0 && SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

            
    }

    public void RemoveEnemy(GameObject gameObject){
        EnemyList.Remove(gameObject);
    }
}
