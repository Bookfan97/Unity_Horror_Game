using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        Debug.Log("Animator: "+ _animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.HaveKnife)
        {
            Debug.Log("_HaveKnife");
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("_HaveKnife + LMB");
                _animator.SetTrigger("KnifeLMB");
            }            
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("_HaveKnife + RMB");
                _animator.SetTrigger("KnifeRMB");
            }
        }        
        if (SaveScript.HaveBat)
        {
            Debug.Log("_HaveBat");
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _animator.SetTrigger("BatLMB");
            }            
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _animator.SetTrigger("BatRMB");
            }
        }        
        if (SaveScript.HaveAxe)
        {
            Debug.Log("_HaveAxe");
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _animator.SetTrigger("AxeLMB");
            }            
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _animator.SetTrigger("AxeRMB");
            }
        }
    }
}
