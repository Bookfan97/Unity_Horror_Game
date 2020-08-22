using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    public Image Fill;
    private float max;
    private float lb; 
    private float hb; 
    //private FirstPersonController FPController;
    // Start is called before the first frame update
    void Start()
    {
        max = FirstPersonController.instance.MAXStamina;
        lb  = FirstPersonController.instance.LightBreathingValue;
        hb = FirstPersonController.instance.HeavyBreathingValue;
        healthSlider.minValue = 0;
        healthSlider.maxValue = max;
        healthSlider.value = FirstPersonController.instance.Stamina1;
        Fill.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        float stamina = FirstPersonController.instance.Stamina1;
        healthSlider.value = stamina;
        if (stamina > lb)
        {
            Fill.color = Color.blue;
        }      
        if (stamina <= lb)
        {
            Fill.color = Color.yellow;
        }
        if (stamina <= hb)
        {
            Fill.color = Color.red;
        }
    }
}
