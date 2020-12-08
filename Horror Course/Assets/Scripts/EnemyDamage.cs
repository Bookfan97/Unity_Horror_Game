using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject Enemy;
    public int EnemyHealth = 100;
    private AudioSource MyPlayer;
    private AudioSource StabSound;
    public bool HasDied = false;
    private Animator Anim;
    [SerializeField] private GameObject EnemyObject;
    [SerializeField] private GameObject BloodSplatKnife;
    [SerializeField] private GameObject BloodSplatBat = null;
    [SerializeField] private GameObject BloodSplatAxe = null;
    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = GetComponent<AudioSource>();
        Anim = GetComponentInParent<Animator>();
        BloodSplatKnife.gameObject.SetActive(false);
        BloodSplatBat.gameObject.SetActive(false);
        BloodSplatAxe.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <=0)
        {
            if (HasDied == false) 
            { 
                Anim.SetTrigger("Death"); 
                //Anim.SetBool("IsDead"); 
                HasDied = true; 
                Destroy(EnemyObject, 25f); 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PKnife"))
        {
            EnemyHealth -= 10;
            MyPlayer.Play();
            StabSound.Play();
            BloodSplatKnife.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("PBat"))
        {
            EnemyHealth -= 25;
            MyPlayer.Play();
            StabSound.Play();
            BloodSplatBat.gameObject.SetActive(true);
        }        
        if (other.gameObject.CompareTag("PAxe"))
        {
            EnemyHealth -= 25;
            MyPlayer.Play();
            StabSound.Play();
            BloodSplatAxe.gameObject.SetActive(true);
        }
    }
}
