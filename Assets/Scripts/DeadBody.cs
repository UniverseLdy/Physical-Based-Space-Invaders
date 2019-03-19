using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody deadbody;
    public float current, last;
    void Start()
    {

        last = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        current = Time.time;
        if(current - last >= 1.0)
        {
            deadbody.GetComponent<CapsuleCollider>().enabled = true;
        }

    }
}
