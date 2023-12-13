using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public TextMeshProUGUI firemodetext;
    WeaponController weaponController;

    void Start()
    {
        weaponController = GameObject.FindWithTag("Player").GetComponentInChildren<WeaponController_Player>();
    }
    void Update()
    {
        switch(weaponController.IsReloading)
        {
            case false:
            tmp.text = $"{weaponController.currentAmmo}/{weaponController.maxAmmo}";
            break;

            case true:
            tmp.text = "Reloading...";
            break;
        }

        switch(weaponController.Automatic)
        {
            case true:
            firemodetext.text = "Firemode: Automatic";
            break;

            case false:
            firemodetext.text = "Firemode: Semi-Automatic";
            break;
        }
    }

    public void SetWeaponController(WeaponController_Player weaponcontroller)
    {
        weaponController = weaponcontroller;
    }

}
