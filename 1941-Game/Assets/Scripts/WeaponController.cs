using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if(currentAmmo <= 0)
        {
            ReloadGun();   
            return;
        }
    }

    void ReloadGun()
    {
        Debug.Log("Reloading...");
        currentAmmo = maxAmmo;
    }
    public void Fire()
    {
        currentAmmo--;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }    
}
