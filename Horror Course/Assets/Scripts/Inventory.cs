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
    [SerializeField] private AudioClip weaponChange;
    [SerializeField] private AudioClip gunShot;
    [SerializeField] private AudioClip arrowShot;
    [SerializeField] private GameObject[] appleImage;
    [SerializeField] private GameObject[] appleButton;
    [SerializeField] private GameObject[] batteryImage;
    [SerializeField] private GameObject[] batteryButton;     
    [SerializeField] private GameObject[] BulletClipImage;
    [SerializeField] private GameObject[] BulletClipButton;
    [SerializeField] private GameObject playerArms;
    [SerializeField] private GameObject Knife;
    [SerializeField] private GameObject Bat;
    [SerializeField] private GameObject Axe;
    [SerializeField] private GameObject Handgun;
    [SerializeField] private GameObject Crossbow;
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
    private float MaxBattery;
    [SerializeField] Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        MaxBattery = BatteryPower.instance.MaxBatteryTime1;
        Debug.Log(MaxBattery);
        Anim = playerArms.GetComponent<Animator>();
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
            SaveMelee();
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
        if (SaveScript.currentBatteryPower < MaxBattery)
        {
            SaveScript.currentBatteryPower += MaxBattery;
            SaveScript.batteryChanged = true;
            --SaveScript.Batteries;
            AudioPlayer.clip = batteryChange;
            AudioPlayer.Stop();
            AudioPlayer.Play();
            if (SaveScript.currentBatteryPower > MaxBattery)
            {
                SaveScript.currentBatteryPower = MaxBattery;
            }
            if (SaveScript.Batteries <= 0)
            {
                SaveScript.Batteries = 0;
                SetBatteries(batteryButton.Length, false);
            }
        }
    }

    public void EquipWeapon(GameObject weaponEquip)
    {
        Debug.Log("Weapon: " + weaponEquip);
        Debug.Log("Knife Test:" + (weaponEquip==Knife) );
        playerArms.gameObject.SetActive(true);
        WeaponsOff();
        weaponEquip.gameObject.SetActive(true);
        if (weaponEquip.gameObject == Handgun.gameObject)
        {
            Anim.SetBool("Melee", false);
            AudioPlayer.clip = gunShot;
        }
        if (weaponEquip == Crossbow)
        {
            Anim.SetBool("Melee", false);
            AudioPlayer.clip = arrowShot;
        }
        if(weaponEquip == Knife || weaponEquip == Bat || weaponEquip == Axe)
        {   
            Anim.SetBool("Melee", true);
            AudioPlayer.clip = weaponChange;
            SaveMelee();
            if (weaponEquip == Knife)
            {
                //Debug.Log("Anim Param: " + Anim.GetParameter(1));
                SaveScript.HaveKnife = true;
            }
            if (weaponEquip == Bat)
            {
                SaveScript.HaveBat = true;
            }
            if (weaponEquip == Axe)
            {
                SaveScript.HaveAxe = true;
            }
         
        }
        AudioPlayer.Play();
    }

    private void SaveMelee()
    {
        SaveScript.HaveKnife = false;
        SaveScript.HaveBat = false;
        SaveScript.HaveAxe = false;
    }

    private void WeaponsOff()
   {
       Axe.gameObject.SetActive(false);
       Bat.gameObject.SetActive(false);
       Knife.gameObject.SetActive(false);
       Handgun.gameObject.SetActive(false);
       Crossbow.gameObject.SetActive(false);
   }
}
