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

    /*private void Start()
    {
        currentPower = SaveScript.currentBatteryPower;
    }*/

    // Update is called once per frame
    void Update()
    {
        BatteryUI.fillAmount -= 1.0f / DrainTime * Time.deltaTime;
        currentPower = BatteryUI.fillAmount;
        SaveScript.currentBatteryPower = currentPower;
        Debug.Log(SaveScript.currentBatteryPower);
    }
}
