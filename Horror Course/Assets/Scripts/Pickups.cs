using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private float Distance = 4.0f;
    [SerializeField] private GameObject pickupMessage;
    private float RayDistance;
    private bool canSeePickup = false;
    // Start is called before the first frame update
    void Start()
    {
        pickupMessage.gameObject.SetActive(false);
        RayDistance = Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if (hit.transform.tag == "Apple")
            {
                canSeePickup = true;
                RayDistance = 1000f;
            }
            else
            {
                canSeePickup = false;
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
        
    }
}
