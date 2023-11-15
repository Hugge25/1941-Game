using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;

public class Ammo : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public WeaponController weaponController;
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
    }


}
