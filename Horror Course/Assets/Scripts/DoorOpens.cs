using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpens : MonoBehaviour
{
    private Animator _animator;
    public bool isOpen = false;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip CabinSound;
    [SerializeField] private AudioClip RoomSound;
    [SerializeField] private AudioClip HouseSound;
    [SerializeField] private bool Cabin;
    [SerializeField] private bool Room;
    [SerializeField] private bool House;
    public bool Locked = true;
    public string DoorType = "...";
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if (Cabin)
        {
            _audioSource.clip = CabinSound;
        }
        else if (Room)
        {
            _audioSource.clip = RoomSound;
        }
        else if (House)
        {
            _audioSource.clip = CabinSound;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Cabin)
        {
            DoorType = "Cabin";
            if (SaveScript.CabinKey)
            {
                Locked = false;
            }
        }
        if (Room)
        {
            DoorType = "Room";
            if (SaveScript.RoomKey)
            {
                Locked = false;
            }
        }
        if (House)
        {
            DoorType = "House";
            if (SaveScript.HouseKey)
            {
                Locked = false;
            }
        }
    }

    public void DoorOpen()
    {
        Debug.Log("Animator: " + _animator);
        if (isOpen == false)
        {
            _animator.SetTrigger("Open");
            _audioSource.Play();
            isOpen = true;
        }
        else if (isOpen == true)
        {
            _animator.SetTrigger("Close");
            _audioSource.Play();
            isOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Locked == false)
            {
                if (isOpen == false)
                {
                    _animator.SetTrigger("Open");
                    _audioSource.Play();
                    isOpen = true;
                }
            }
        }
    }
}
