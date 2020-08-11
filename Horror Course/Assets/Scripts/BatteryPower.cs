using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    [SerializeField] private Image BatteryUI;
    [SerializeField] private float DrainTime = 15.0f;
    [SerializeField] private float currentPower;

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.FlashlightOn || SaveScript.NightVisionOn)
        {
            BatteryUI.fillAmount -= 1.0f / DrainTime * Time.deltaTime;
            currentPower = BatteryUI.fillAmount;
            SaveScript.currentBatteryPower = currentPower;
            //Debug.Log(SaveScript.currentBatteryPower);
        }
        if (SaveScript.batteryChanged)
        {
            SaveScript.healthChanged = false;
            BatteryUI.fillAmount = SaveScript.currentBatteryPower;
        }
    }
}
