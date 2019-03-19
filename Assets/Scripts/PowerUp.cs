using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject spaceship;
    public float move_speed;
    public Rigidbody Self;
    public float current, last, interval;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Self.velocity = (new Vector3(move_speed, 0, (Mathf.Sin(Time.time * 2) * 18.5f)));
    }
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bullet")
        {

            Spaceship.bullet_limit = 100;
            Spaceship.superfire = true;
            Score.score += 50;
            Destroy(gameObject);
            last = Time.time;
        }
    }
}
