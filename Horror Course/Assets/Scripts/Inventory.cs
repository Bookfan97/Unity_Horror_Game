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
    [SerializeField] private GameObject[] BulletClipImage;
    [SerializeField] private GameObject[] BulletClipButton;
    [SerializeField] private GameObject ArrowRefillImage;
    [SerializeField] private GameObject ArrowRefillButton;   
    [SerializeField] private GameObject KnifeImage;
    [SerializeField] private GameObject KnifeButton;
    [SerializeField] private GameObject BatImage;
    [SerializeField] private GameObject BatButton;
    [SerializeField] private GameObject AxeImage;
    [SerializeField] private GameObject AxeButton;
    [SerializeField] private GameObject HandgunImage;
    [SerializeField] private GameObject HandgunButton;
    [SerializeField] private GameObject CrossbowImage;
    [SerializeField] private GameObject CrossbowButton;
    [SerializeField] private GameObject HouseKeyImage;
    [SerializeField] private GameObject CabinKeyImage;
    [SerializeField] private GameObject RoomKeyImage;
    private bool InventoryActive = false;
    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
        SetApples(appleButton.Length,false);
        SetBatteries(batteryButton.Length, false);
        SetBulletClips(BulletClipButton.Length, false);
        ArrowRefillImage.gameObject.SetActive(false);
        ArrowRefillButton.gameObject.SetActive(false);
        KnifeImage.gameObject.SetActive(false);
        KnifeButton.gameObject.SetActive(false);
        BatImage.gameObject.SetActive(false);
        BatButton.gameObject.SetActive(false);
        AxeImage.gameObject.SetActive(false);
        AxeButton.gameObject.SetActive(false);
        HandgunImage.gameObject.SetActive(false);
        HandgunButton.gameObject.SetActive(false);
        CrossbowImage.gameObject.SetActive(false);
        CrossbowButton.gameObject.SetActive(false);
        HouseKeyImage.gameObject.SetActive(false);
        CabinKeyImage.gameObject.SetActive(false);
        RoomKeyImage.gameObject.SetActive(false);
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
    private void SetBulletClips(int numMax, bool toSet)
    {
        if (numMax > BulletClipButton.Length)
        {
            numMax = BulletClipButton.Length;
        }
        for (int i = 0; i < numMax; i++)
        {
            BulletClipImage[i].gameObject.SetActive(toSet);
            BulletClipButton[i].gameObject.SetActive(toSet);
        }
        if (numMax != appleButton.Length)
        {
            for (int i = numMax; i < BulletClipButton.Length; i++)
            {
                BulletClipImage[i].gameObject.SetActive(!toSet);
                BulletClipButton[i].gameObject.SetActive(!toSet);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// || Input.GetKeyDown(KeyCode.I))
        {
            InventoryActive = !InventoryActive;
            InventoryMenu.gameObject.SetActive(InventoryActive);
            Cursor.visible = InventoryActive;
            if (InventoryActive)
            {
                //Cursor.visible = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                //Cursor.visible = false;
                Time.timeScale = 1f;
            }
        }
        CheckInventory();
        CheckAmmo();
        CheckKeys();
        CheckWeapons();
    }

    private void CheckInventory()
    {
        if (SaveScript.Apples >= 1)
        {
            SetApples(SaveScript.Apples, true);
        }        
        if (SaveScript.Batteries >= 1)
        {
            SetBatteries(SaveScript.Batteries, true);
        }
    }

    private void CheckKeys()
    {
        if (SaveScript.HouseKey)
        {
            HouseKeyImage.gameObject.SetActive(true);
        }

        if (SaveScript.CabinKey)
        {
            CabinKeyImage.gameObject.SetActive(true);
        }

        if (SaveScript.RoomKey)
        {
            RoomKeyImage.gameObject.SetActive(true);
        }
    }

    private void CheckWeapons()
    {
        if (SaveScript.Knife)
        {
            KnifeImage.gameObject.SetActive(true);
            KnifeButton.gameObject.SetActive(true);
        }

        if (SaveScript.Bat)
        {
            BatImage.gameObject.SetActive(true);
            BatButton.gameObject.SetActive(true);
        }

        if (SaveScript.Axe)
        {
            AxeImage.gameObject.SetActive(true);
            AxeButton.gameObject.SetActive(true);
        }

        if (SaveScript.HandGun)
        {
            HandgunImage.gameObject.SetActive(true);
            HandgunButton.gameObject.SetActive(true);
        }

        if (SaveScript.Crossbow)
        {
            CrossbowImage.gameObject.SetActive(true);
            CrossbowButton.gameObject.SetActive(true);
        }
    }

    private void CheckAmmo()
    {
        Debug.Log("SaveScript.BulletClips = "+ SaveScript.BulletClips);
        if (SaveScript.BulletClips >= 1)
        {
            SetBulletClips(SaveScript.BulletClips, true);
        }

        if (SaveScript.ArrowRefill)
        {
            ArrowRefillButton.gameObject.SetActive(true);
            ArrowRefillImage.gameObject.SetActive(true);
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
