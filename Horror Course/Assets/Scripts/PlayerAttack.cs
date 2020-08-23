using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private GameObject FPSarms;
    // Start is called before the first frame update
    void Start()
    {
        _animator = FPSarms.GetComponent<Animator>();
        //Debug.Log("Animator: "+ _animator);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("_HaveKnife = "+ SaveScript.HaveKnife );
        if (SaveScript.HaveKnife)
        {
            //Debug.Log("_HaveKnife = "+ SaveScript.HaveKnife );
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                //Debug.Log("_HaveKnife + LMB");
                _animator.SetTrigger("KnifeLMB");
                //_animator.Play("KnifeLMB");
            }            
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //Debug.Log("_HaveKnife + RMB");
                _animator.SetTrigger("KnifeRMB");
            }
        }        
        if (SaveScript.HaveBat)
        {
            //Debug.Log("_HaveBat");
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
            //Debug.Log("_HaveAxe");
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
