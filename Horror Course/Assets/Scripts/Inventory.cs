using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject InventoryMenu;

    private bool InventoryActive = false;
    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
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
    }
}
