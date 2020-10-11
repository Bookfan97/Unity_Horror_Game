using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{
    [SerializeField] private int WeaponDamage = 10;
    [SerializeField] private Animator hurtAnim;
    [SerializeField] private AudioSource stabSound;
    [SerializeField] private GameObject FPSArms;
    private bool hitActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == false)
            {
                hitActive = true;
                hurtAnim.SetTrigger("Hurt");
                SaveScript.PlayerHealth -= WeaponDamage;
                SaveScript.healthChanged = true;
                stabSound.Play();
                FPSArms.GetComponent<PlayerAttack>().AttackStamina -= 0.2f;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == true)
            {
                hitActive = false;
            }
        }
    }
}
