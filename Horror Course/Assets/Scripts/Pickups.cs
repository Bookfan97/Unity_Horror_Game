using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private float Distance = 4.0f;
    [SerializeField] private GameObject pickupMessage;
    [SerializeField] private GameObject doorMessage;
    [SerializeField] GameObject PlayerArms;
    [SerializeField] private Text DoorText;
    private AudioSource AudioPlayer;
    private float RayDistance;
    private bool canSeePickup = false, canSeeDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        pickupMessage.gameObject.SetActive(false);
        doorMessage.gameObject.SetActive(false);
        PlayerArms.gameObject.SetActive(false);
        RayDistance = Distance;
        AudioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if (hit.transform.tag == "Apple")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Apples < 6)
                    {
                        Destroy(hit.transform.gameObject); 
                        AudioPlayer.Play();
                        SaveScript.Apples++;
                    }
                    
                }
            }
            else if (hit.transform.tag == "Battery")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Batteries < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play();
                        SaveScript.Batteries++;
                    }
                }
            }                  
            else if (hit.transform.tag == "BulletClip")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.BulletClips < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play();
                        SaveScript.BulletClips++;
                    }
                }
            }            
            else if (hit.transform.tag == "ArrowRefill")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.ArrowRefill)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play(); 
                        SaveScript.ArrowRefill = true;
                    }
                }
            }               
            else if (hit.transform.tag == "Knife")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.Knife)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play(); 
                        SaveScript.Knife = true;
                    }
                }
            }           
            else if (hit.transform.tag == "Axe")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.Axe)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play();
                        SaveScript.Axe = true;
                    }
                }
            }            
            else if (hit.transform.tag == "Bat")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.Bat)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play();
                        SaveScript.Bat = true;
                    }
                }
            }
            else if (hit.transform.tag == "Crossbow")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.Crossbow)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play();
                        SaveScript.Crossbow = true;
                    }
                }
            }
            else if (hit.transform.tag == "Handgun")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.HandGun)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play();
                        SaveScript.HandGun = true;
                    }
                }
            }                  
            else if (hit.transform.tag == "Door")
            {
                canSeeDoor = true;
                //canSeePickup = true;
                if (hit.transform.gameObject.GetComponent<DoorOpens>().isOpen == false)
                {
                    DoorText.text = "Press E to open";
                }
                if (hit.transform.gameObject.GetComponent<DoorOpens>().isOpen == true)
                {
                    DoorText.text = "Press E to close";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Debug.Log("Door Open: " + hit.transform.gameObject);
                    hit.transform.gameObject.SendMessage("DoorOpen");
                }
            }            
            else if (hit.transform.tag == "House Key")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.HouseKey)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play();
                        SaveScript.HouseKey = true;
                    }
                }
            }            
            else if (hit.transform.tag == "Cabin Key")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.CabinKey)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play();
                        SaveScript.CabinKey = true;
                    }
                }
            }
            else if (hit.transform.tag == "Room Key")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!SaveScript.RoomKey)
                    {
                        Destroy(hit.transform.gameObject);
                        AudioPlayer.Play();
                        SaveScript.RoomKey = true;
                    }
                }
            }
            else
            {
                canSeePickup = false;
                canSeeDoor = false;
            }
        }

        if (canSeePickup == true)
        {
            pickupMessage.gameObject.SetActive(true);
            RayDistance = 1000f;
        }

        if (canSeePickup == false)
        {
            pickupMessage.gameObject.SetActive(false);
            RayDistance = Distance;
        }        
        
        if (canSeeDoor == true)
        {
            doorMessage.gameObject.SetActive(true);
            RayDistance = 1000f;
        }

        if (canSeeDoor == false)
        {
            doorMessage.gameObject.SetActive(false);
            RayDistance = Distance;
        }
        
    }
}
