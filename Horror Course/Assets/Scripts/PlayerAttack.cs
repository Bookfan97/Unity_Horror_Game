using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private GameObject FPSarms;
    [SerializeField] private GameObject Knife;
    public float AttackStamina = 10;
    [SerializeField] private float MaxAttackStamina = 10;
    [SerializeField] private float AttackRefill = 1;
    [SerializeField] private float AttackDrain = 2;
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private GameObject Pointer;
    // Start is called before the first frame update
    void Start()
    {
        _animator = FPSarms.GetComponent<Animator>();
        AttackStamina = MaxAttackStamina;
        Crosshair.gameObject.SetActive(false);
        Pointer.gameObject.SetActive(true);
        //Debug.Log("Animator: "+ _animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackStamina < MaxAttackStamina)
        {
            AttackStamina += AttackRefill * Time.deltaTime;
        }
        if(AttackStamina <= 0.1)
        {
            AttackStamina = 0.1f;
        }
        if (AttackStamina > 3)
        {
            //Knife.gameObject.tag = "Untagged";
            //Debug.Log("_HaveKnife = "+ SaveScript.HaveKnife );
            if (SaveScript.HaveKnife)
            {
                //Debug.Log("_HaveKnife = "+ SaveScript.HaveKnife );
                if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    //Debug.Log("_HaveKnife + LMB");
                    _animator.SetTrigger("KnifeLMB");
                    Knife.gameObject.tag = "Knife";
                    AttackStamina -= AttackDrain;
                    //_animator.Play("KnifeLMB");
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    //Debug.Log("_HaveKnife + RMB");
                    _animator.SetTrigger("KnifeRMB");
                    FPSarms.gameObject.tag = "Knife";
                    AttackStamina -= AttackDrain;
                }
            }

            if (SaveScript.HaveBat)
            {
                //Debug.Log("_HaveBat");
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _animator.SetTrigger("BatLMB");
                    AttackStamina -= AttackDrain;
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    _animator.SetTrigger("BatRMB");
                    AttackStamina -= AttackDrain;
                }
            }

            if (SaveScript.HaveAxe)
            {
                //Debug.Log("_HaveAxe");
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _animator.SetTrigger("AxeLMB");
                    AttackStamina -= AttackDrain;
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    _animator.SetTrigger("AxeRMB");
                    AttackStamina -= AttackDrain;
                }
            }
            
            if (SaveScript.HaveGun)
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    _animator.SetBool("AimGun", true);
                    Crosshair.gameObject.SetActive(true);
                    Pointer.gameObject.SetActive(false);
                }
                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    _animator.SetBool("AimGun", false);
                    Crosshair.gameObject.SetActive(true);
                    Pointer.gameObject.SetActive(false);
                }
            }
        }
    }
}