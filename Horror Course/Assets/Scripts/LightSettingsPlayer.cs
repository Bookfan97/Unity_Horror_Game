using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class LightSettingsPlayer : MonoBehaviour
{
    [SerializeField] private PostProcessVolume currentVolume;
    [SerializeField] private PostProcessProfile Standard;
    [SerializeField] private PostProcessProfile NightVision;
    [SerializeField] private GameObject NightVisionHUD;
    private bool NightVisionActive = false;

    private void Start()
    {
        NightVisionHUD.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (NightVisionActive == false)
            {
                NightVisionActive = true;
                currentVolume.profile = NightVision;
                NightVisionHUD.gameObject.SetActive(true);
            }
            else
            {
                NightVisionActive = false;
                currentVolume.profile = Standard;
                NightVisionHUD.gameObject.SetActive(false);
            }
        }
    }
}
