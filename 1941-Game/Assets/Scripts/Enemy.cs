using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject enemy;

    Transform player;

    Vector3 position;

    void Start()
    {
        maxHealth = 100f;
        player = PlayerManager.instance.player.transform;
        currentHealth = maxHealth;
        position = gameObject.transform.position;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        var DistanceToPlayer = Vector2.Distance(player.position, gameObject.transform.position);

        if(DistanceToPlayer <= 10 && DistanceToPlayer >= 4)
        {
            //gör attackgrejer här
            if(player.position.y > gameObject.transform.position.y)
            {
                position.y += 1 * Time.deltaTime;
            }

            if(player.position.y < gameObject.transform.position.y)
            {
                position.y -= 1 * Time.deltaTime;
            }

            if(player.position.x > gameObject.transform.position.x)
            {
                position.x += 1 * Time.deltaTime;
            }

            if(player.position.x < gameObject.transform.position.x)
            {
                position.x -= 1 * Time.deltaTime;
            }

            gameObject.transform.position = position;
        }
    }
    //private void OnCollisionEnter2D(Collision2D other) 
    //{
        //if(other.transform.CompareTag("Bullet"))
        //{
            //currentHealth -= 20;
        //}
    //}
     public Vector2 GetHealth()
    {
        return new Vector2(currentHealth, maxHealth);
    }


}
