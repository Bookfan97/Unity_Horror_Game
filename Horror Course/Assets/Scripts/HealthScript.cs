using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    public Image Fill;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.minValue = 0f;
        healthSlider.maxValue = 100;
        healthSlider.value = SaveScript.PlayerHealth; 
        healthSlider.value = SaveScript.PlayerHealth;
        Fill.color = Color.Lerp(Color.red, Color.green, (float) SaveScript.PlayerHealth / 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.healthChanged)
        {
            SaveScript.healthChanged = false;
            healthSlider.value = SaveScript.PlayerHealth;
            Fill.color = Color.Lerp(Color.red, Color.green, (float) SaveScript.PlayerHealth / 100);
        }
    }
}
