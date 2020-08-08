using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class OneshotAudio : MonoBehaviour
{
    private AudioSource AudioSource;
    private Collider attachedCollider;
    [SerializeField] private float pauseTime = 5.0f;
    [SerializeField] private bool isReusable = false;
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
            if (isReusable)
            {
                StartCoroutine(Reset());
            }
            else
            {
                Destroy(gameObject, pauseTime);
            }
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(pauseTime);
        attachedCollider.enabled = true;
    }
}
