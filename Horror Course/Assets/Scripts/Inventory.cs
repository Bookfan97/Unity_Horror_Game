using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject InventoryMenu;
    private AudioSource AudioPlayer;
    [SerializeField] private AudioClip appleBite; 
    [SerializeField] private AudioClip batteryChange;
    [SerializeField] private GameObject[] appleImage;
    [SerializeField] private GameObject[] appleButton;
    [SerializeField] private GameObject[] batteryImage;
    [SerializeField] private GameObject[] batteryButton;
    private bool InventoryActive = false;
    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
        SetApples(appleButton.Length,false);
        SetBatteries(batteryButton.Length, false);
        AudioPlayer = GetComponent<AudioSource>();
        InventoryActive = false;
        Cursor.visible = false;
    }

    private void SetBatteries(int numMax, bool toSet)
    {
        if (numMax > batteryButton.Length)
        {
            numMax = batteryButton.Length;
        }
        for (int i = 0; i < numMax; i++)
        {
            batteryImage[i].gameObject.SetActive(toSet);
            batteryButton[i].gameObject.SetActive(toSet);
        }

        if (numMax != batteryButton.Length)
        {
            for (int i = numMax; i < batteryImage.Length; i++)
            {
                batteryImage[i].gameObject.SetActive(!toSet);
                batteryButton[i].gameObject.SetActive(!toSet);
            }
        }
    }

    private void SetApples(int numMax, bool toSet)
    {
        if (numMax > appleButton.Length)
        {
            numMax = appleButton.Length;
        }
        for (int i = 0; i < numMax; i++)
        {
            appleImage[i].gameObject.SetActive(toSet);
            appleButton[i].gameObject.SetActive(toSet);
        }
        if (numMax != appleButton.Length)
        {
            for (int i = numMax; i < appleImage.Length; i++)
            {
                appleImage[i].gameObject.SetActive(!toSet);
                appleButton[i].gameObject.SetActive(!toSet);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InventoryActive = !InventoryActive;
            InventoryMenu.gameObject.SetActive(InventoryActive);
            Cursor.visible = InventoryActive;
            if (InventoryActive)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        CheckInventory();
    }

    private void CheckInventory()
    {
        if (SaveScript.Apples >= 1)
        {
            SetApples(SaveScript.Apples, true);
        }        
        else if (SaveScript.Batteries >= 1)
        {
            SetBatteries(SaveScript.Batteries, true);
        }
    }

    public void HealthUpdate()
    {
        if (SaveScript.PlayerHealth < 100)
        {
            SaveScript.PlayerHealth += 10;
            SaveScript.healthChanged = true;
            --SaveScript.Apples;
            AudioPlayer.clip = appleBite;
            AudioPlayer.Stop();
            AudioPlayer.Play();
            if (SaveScript.PlayerHealth > 100)
            {
                SaveScript.PlayerHealth = 100;
            }
            if (SaveScript.Apples <= 0)
            {
                SaveScript.Apples = 0;
                SetApples(appleButton.Length, false);
            }
        }
    }

    public void BatteryUpdate()
    {
        if (SaveScript.currentBatteryPower < 15.0f)
        {
            SaveScript.currentBatteryPower += 15;
            SaveScript.batteryChanged = true;
            --SaveScript.Batteries;
            AudioPlayer.clip = batteryChange;
            AudioPlayer.Stop();
            AudioPlayer.Play();
            if (SaveScript.currentBatteryPower > 15.0f)
            {
                SaveScript.currentBatteryPower = 15.0f;
            }
            if (SaveScript.Batteries <= 0)
            {
                SaveScript.Batteries = 0;
                SetBatteries(batteryButton.Length, false);
            }
        }
    }
}
