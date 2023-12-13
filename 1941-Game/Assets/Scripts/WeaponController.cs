using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public int maxAmmo = 10;

    public bool Automatic;
    public float Damage = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    public bool IsReloading;
    protected bool Canfire = true;
    public float fireRate = 1f;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if(currentAmmo <= 0 && !IsReloading)
        {
            StartCoroutine (ReloadGun());
            IsReloading = true;   
            return;
        }

        //else if(Input.GetKeyDown(KeyCode.R) && !IsReloading)
        //{
            //StartCoroutine (ReloadGun());
            //IsReloading = true;
            //return;
        //}
    }

    //void ReloadGun()
    //{
        //Debug.Log("Reloading...");
        //currentAmmo = maxAmmo;
    //}
    public void Fire()
    {
        if(currentAmmo > 0 && !IsReloading && Canfire)
        {
            Canfire = false;
            StartCoroutine(FireRate());
            currentAmmo--;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().SetDamage(Damage);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
        }
    }

    protected IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        IsReloading = false;
    }
    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireRate);
        Canfire = true;
    }    
}
