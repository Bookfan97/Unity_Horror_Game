﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject InventoryMenu;
    [SerializeField] private GameObject appleImage;
    [SerializeField] private GameObject appleButton;
    private bool InventoryActive = false;
    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
        appleImage.gameObject.SetActive(false);
        appleButton.gameObject.SetActive(false);
        InventoryActive = false;
        Cursor.visible = false;
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
            appleImage.gameObject.SetActive(true);
            appleButton.gameObject.SetActive(true);
        }
    }

    public void HealthUpdate()
    {
        SaveScript.PlayerHealth += 10;
        SaveScript.healthChanged = true;
        --SaveScript.Apples;
        if (SaveScript.Apples <=0)
        {
            appleImage.gameObject.SetActive(false);
            appleButton.gameObject.SetActive(false);
        }
    }
}
