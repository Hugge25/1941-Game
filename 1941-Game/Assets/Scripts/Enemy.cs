using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject enemy;
    Transform player;
    private int speed = 2;
    Vector3 position;
    public Rigidbody2D rb_g;
    public Rigidbody2D rb;
    public WeaponController weaponController;
    public GameObject Gun;
    Vector2 movement;

    void Start()
    {
        maxHealth = 100f;
        player = PlayerManager.instance.player.transform;
        currentHealth = maxHealth;
        position = gameObject.transform.position;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector3 lookDir = player.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb_g.rotation = angle;

        
        if(angle < 89 && angle > -89) {
            Gun.transform.localScale = new Vector3(1, 1, 1);
        }
        else{
            Gun.transform.localScale = new Vector3(1, -1, 1);
        }
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
                position.y += speed * Time.deltaTime;
            }

            if(player.position.y < gameObject.transform.position.y)
            {
                position.y -= speed * Time.deltaTime;
            }

            if(player.position.x > gameObject.transform.position.x)
            {
                position.x += speed * Time.deltaTime;
            }

            if(player.position.x < gameObject.transform.position.x)
            {
                position.x -= speed * Time.deltaTime;
            }

            gameObject.transform.position = position;

            weaponController.Fire();

            
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
