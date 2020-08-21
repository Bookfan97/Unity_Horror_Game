using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    public Image Fill;
    //private FirstPersonController FPController;
    // Start is called before the first frame update
    void Start()
    {
        //FPController = GetComponent<FirstPersonController>();
        healthSlider.minValue = 0;
        healthSlider.maxValue = FirstPersonController.instance.MAXStamina;
        healthSlider.value = FirstPersonController.instance.Stamina1;
        Fill.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        float stamina = FirstPersonController.instance.Stamina1;
        healthSlider.value = stamina;
        if (stamina > FirstPersonController.instance.LightBreathingValue)
        {
            Fill.color = Color.blue;
        }      
        if (stamina <= FirstPersonController.instance.LightBreathingValue)
        {
            Fill.color = Color.yellow;
        }
        if (stamina <= FirstPersonController.instance.HeavyBreathingValue)
        {
            Fill.color = Color.red;
        }
    }
}
