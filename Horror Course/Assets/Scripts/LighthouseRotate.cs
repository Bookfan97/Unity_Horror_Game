using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseRotate : MonoBehaviour
{
    [SerializeField] private GameObject LighthouseBeacon;
    [SerializeField] private float Speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LighthouseBeacon.transform.Rotate(0.0f, Speed, 0.0f, Space.World);
    }
}
