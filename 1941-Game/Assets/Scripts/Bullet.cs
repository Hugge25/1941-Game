using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    private float Timer;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.CompareTag("Enemy"))
        {
            Destroy(bullet);
        }    
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
