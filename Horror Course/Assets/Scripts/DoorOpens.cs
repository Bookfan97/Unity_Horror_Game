using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpens : MonoBehaviour
{
    private Animator _animator;
    public bool isOpen = false;
    private static readonly int Open = Animator.StringToHash("Open");
    private static readonly int Close = Animator.StringToHash("Close");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpen()
    {
        Debug.Log("Animator: " + _animator);
        if (isOpen == false)
        {
            _animator.SetTrigger("Open");
            isOpen = true;
        }
        else if (isOpen == true)
        {
            _animator.SetTrigger("Close");
            isOpen = false;
        }
    }

    public void DoorClose()
    {
        
    }
}
