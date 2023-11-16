using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerController playercontroller;
    public Enemy enemy;

    void Update()
    {
        if(playercontroller != null)
        {
            var HealthStats = playercontroller.GetHealth();
            slider.value = HealthStats.x;
            slider.maxValue = HealthStats.y;
        }

        else if(enemy != null)
        {
            var HealthStats = enemy.GetHealth();
            slider.value = HealthStats.x;
            slider.maxValue = HealthStats.y;
        }

    }
    
}
