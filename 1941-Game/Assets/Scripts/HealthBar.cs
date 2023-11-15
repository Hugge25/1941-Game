using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerController playercontroller;

    void Update()
    {
        var HealthStats = playercontroller.GetHealth();
        slider.value = HealthStats.x;
        slider.maxValue = HealthStats.y;
    }
    
}
