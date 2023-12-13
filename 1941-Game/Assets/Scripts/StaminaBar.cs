using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public PlayerController playercontroller;

    void Update()
    {
        var StaminaStats = playercontroller.GetStamina();
        slider.value = StaminaStats.x;
        slider.maxValue = StaminaStats.y;
    }
}
