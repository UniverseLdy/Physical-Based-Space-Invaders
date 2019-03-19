using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector3 thrust = new Vector3(0, 0, -400.0f);
    public GameObject Bullet;
    public Quaternion heading;
    public float time_interval = 12.0f;
    private float last_time, current_time;
    public bool can_kill;
    // Start is called before the first frame update
    void Start()
    {
        last_time = Time.time;
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
        gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
        can_kill = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_pos = Bullet.transform.position;
        current_time = Time.time;
        if ((current_time - last_time) >= time_interval)
        {
            Destroy(gameObject);
            last_time = current_time;
            GameManager.firecount -= 1;
        }
        if (current_pos.z <= -40.0f)
        {
            Bullet.GetComponent<SphereCollider>().enabled = true;
        }
        if (current_pos.z <= -48.0f)
        {
            Destroy(gameObject);
            GameManager.firecount -= 1;
        }
    }
   public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "ship" && can_kill == true )
        {
            Debug.Log("ship collide!!!");
            Destroy(gameObject);
            GameManager.firecount -= 1;
        }
        if (collisionInfo.collider.tag == "Plane")
        {
            Debug.Log(Time.time);
            can_kill = false;
        }
    }
}
