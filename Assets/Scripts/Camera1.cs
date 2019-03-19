using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    public GameObject plane;
    public Vector3 offset = new Vector3(0, 120, 0);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = plane.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
