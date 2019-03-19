using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
    public Vector3 thrust = new Vector3(-100.0f, 0, 400.0f);
    public Quaternion heading;
    public float time_interval = 6.0f;
    private float last_time, current_time;
    public GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        last_time = Time.time;
        GetComponent<Rigidbody>().AddForce(thrust);
        gameObject.transform.Rotate(new Vector3(0.0f, 90.0f, 90.0f));
    }

    // Update is called once per frame
    void Update()
    {
        current_time = Time.time;
        if ((current_time - last_time) >= time_interval)
        {
            Destroy(gameObject);
            last_time = current_time;

        }
    }
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            Enemy enm = collisionInfo.collider.gameObject.GetComponent<Enemy>();
            enm.playsound();
            Debug.Log("collide!!!");
            Destroy(gameObject);
        }
        if (collisionInfo.collider.tag == "UFO")
        {
            UFO enm = collisionInfo.collider.gameObject.GetComponent<UFO>();
            enm.playsound();
            Debug.Log("collide!!!");
            Destroy(gameObject);
        }
    }
}
