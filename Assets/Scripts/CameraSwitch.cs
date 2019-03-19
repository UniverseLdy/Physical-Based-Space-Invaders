using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject camera1, camera2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("2"))
        {
            camera1.GetComponent<Camera>().enabled = false;
            camera2.GetComponent<Camera>().enabled = true;
        }
        if (Input.GetKey("1"))
        {
            camera1.GetComponent<Camera>().enabled = true;
            camera2.GetComponent<Camera>().enabled = false;
        }
    }
}
