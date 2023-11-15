using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public PlayerController playerController;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.CompareTag("Bullet"))
        {
            playerController.TakeDamage(20);
        }
    }
}
