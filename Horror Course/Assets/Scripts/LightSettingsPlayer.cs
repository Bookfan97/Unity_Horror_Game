using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LightSettingsPlayer : MonoBehaviour
{
    [SerializeField] private PostProcessVolume currentVolume;
    [SerializeField] private PostProcessProfile Standard;
    [SerializeField] private PostProcessProfile NightVision;
    [SerializeField] private GameObject NightVisionHUD;
    [SerializeField] private GameObject Flashlight;    
    [SerializeField] private GameObject EnemyFlashlight;
    [SerializeField] private Light theFlashlight;
    private bool NightVisionActive = false;
    private bool FlashlightActive = false;
    private float minFlickerIntensity = 0.5f;
    private float maxFlickerIntensity = 2.5f;
    private float flickerSpeed = 0.035f;
    private int randomizer = 0;
    
    private void Start()
    {
        NightVisionHUD.gameObject.SetActive(false);
        Flashlight.gameObject.SetActive(false);
        EnemyFlashlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.currentBatteryPower > 0)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (NightVisionActive == false)
                {
                    NightVisionActive = true;
                    currentVolume.profile = NightVision;
                    NightVisionHUD.gameObject.SetActive(true);
                    SaveScript.NightVisionOn = true;
                }
                else
                {
                    NightVisionActive = false;
                    currentVolume.profile = Standard;
                    NightVisionHUD.gameObject.SetActive(false);
                    SaveScript.NightVisionOn = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                FlashlightActive = !FlashlightActive;
                Flashlight.gameObject.SetActive(FlashlightActive);
                EnemyFlashlight.gameObject.SetActive(FlashlightActive);
                SaveScript.FlashlightOn = FlashlightActive;
                /*if (SaveScript.currentBatteryPower <= 0.5f)
                {
                    //float flickerIntensity = Random.Range(0.05f, 2.0f);
                    //theFlashlight.intensity = flickerIntensity;
                    //Debug.Log(theFlashlight.intensity);
                    theFlashlight.intensity = Random.Range(0.5f, 2.0f);
                    Debug.Log("Intensity: " + theFlashlight.intensity);
                }
                Debug.Log("Intensity: " + theFlashlight.intensity);*/
            }
        }
        else
        {
            if (FlashlightActive)
            {            
                FlashlightActive = false; 
                Flashlight.gameObject.SetActive(FlashlightActive);
                EnemyFlashlight.gameObject.SetActive(FlashlightActive);
                SaveScript.FlashlightOn = FlashlightActive;
            }
            else if (NightVisionActive)
            {
                    NightVisionActive = false;
                    currentVolume.profile = Standard;
                    NightVisionHUD.gameObject.SetActive(false);
                    SaveScript.NightVisionOn = false;
            }
        }
    }
}
