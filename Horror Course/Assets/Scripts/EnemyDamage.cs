using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject Enemy;
    public int EnemyHealth = 100;
    private AudioSource MyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(Enemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knife"))
        {
            EnemyHealth -= 50;
            MyPlayer.Play();
        }
    }
}
