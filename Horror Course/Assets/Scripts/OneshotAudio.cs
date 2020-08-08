using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneshotAudio : MonoBehaviour
{
    private AudioSource AudioSource;
    private Collider attachedCollider;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        attachedCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.Stop();
            AudioSource.Play();
            attachedCollider.enabled = false;
        }
    }
}
