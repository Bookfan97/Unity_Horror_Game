using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    public static BatteryPower instance;
    [SerializeField] private Image BatteryUI;
    [SerializeField] private float DrainTime = 180.0f;
    [SerializeField] private float MaxBatteryTime = 180.0f;
    [SerializeField] private float currentPower;
    

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.FlashlightOn || SaveScript.NightVisionOn)
        {
            BatteryUI.fillAmount -= 1.0f / DrainTime * Time.deltaTime;
            currentPower = BatteryUI.fillAmount;
            SaveScript.currentBatteryPower = currentPower;
            Debug.Log(SaveScript.currentBatteryPower);
        }
        if (SaveScript.batteryChanged)
        {
            SaveScript.healthChanged = false;
            BatteryUI.fillAmount = SaveScript.currentBatteryPower;
        }
    }

    public float MaxBatteryTime1 => MaxBatteryTime;
}
