using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    private float Timer;

    private float Damage;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.GetComponent<Entity>() != null)
        {
            other.transform.GetComponent<Entity>().TakeDamage(Damage);
        }
            Destroy(bullet);
    }

    public void SetDamage(float damage)
    {
        Damage = damage;
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 1f)
        {
            timerEnd();
        }
    }

    void timerEnd()
    {
        Destroy(bullet);
    }
}
