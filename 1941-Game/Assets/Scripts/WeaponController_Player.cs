using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController_Player : WeaponController
{

    PlayerController playercontroller;
    void Start()
    {
        currentAmmo = maxAmmo;
        playercontroller = gameObject.transform.parent.GetComponent<PlayerController>();

        var rb_g = gameObject.GetComponent<Rigidbody2D>();
        playercontroller = gameObject.transform.parent.GetComponent<PlayerController>();
        playercontroller.UpdateGunRB(rb_g, gameObject);
        var Ammobar = GameObject.FindWithTag("UI").GetComponentInChildren<Ammo>();
        Ammobar.SetWeaponController(gameObject.GetComponent<WeaponController_Player>());
    }

    void OnEnable()
    {
        var rb_g = gameObject.GetComponent<Rigidbody2D>();
        playercontroller = gameObject.transform.parent.GetComponent<PlayerController>();
        playercontroller.UpdateGunRB(rb_g, gameObject);
        var Ammobar = GameObject.FindWithTag("UI").GetComponentInChildren<Ammo>();
        Ammobar.SetWeaponController(gameObject.GetComponent<WeaponController_Player>());
        Canfire = true;
        IsReloading = false;
    }

    void Update()
    {
        if(currentAmmo <= 0 && !IsReloading)
        {
            StartCoroutine (ReloadGun());
            IsReloading = true;   
            return;
        }

        else if(Input.GetKeyDown(KeyCode.R) && !IsReloading)
        {
            StartCoroutine (ReloadGun());
            IsReloading = true;
            return;
        }

        switch(Automatic)
        {
            case false:
                if(Input.GetMouseButtonDown(0))
                  {
                     Fire();
                  }
            break;

            case true:
                if(Input.GetMouseButton(0))
                  {
                     Fire();
                  }
            break;
        }
    }

    //void ReloadGun()
    //{
        //Debug.Log("Reloading...");
        //currentAmmo = maxAmmo;
    //} 
}
