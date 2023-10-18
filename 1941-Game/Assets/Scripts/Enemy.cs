using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(enemy);
    }

}
