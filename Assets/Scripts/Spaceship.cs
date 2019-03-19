using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    public Rigidbody ship;
    public GameObject spaceship;
    public GameObject MainCamera;
    public ParticleSystem exp;
    public float speed = 20f;
    public float force;
    public Vector3 bound;
    public GameObject bullet;
    public AudioClip explode;
    static public int bullet_limit;
    static public bool superfire;
    static public int bulletcount;
    public bool rebirth;
    public float current;
    void Start()
    {
        bulletcount = 0;
        bullet_limit = 1;
        rebirth = false;
        current = 0.0f;
        superfire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletcount <=bullet_limit)
        {
            if(superfire)
            {
                Debug.Log("Fire!");
                Vector3 CurrentPos = ship.transform.position;
                Vector3 offset1 = new Vector3(0, 0, 3);
                Vector3 offset2 = new Vector3(2, 0, 1);
                Vector3 offset3 = new Vector3(-2, 0, 1);
                GameObject obj = Instantiate(bullet, CurrentPos + offset1, Quaternion.identity) as GameObject;
                obj.GetComponent<Bullet>().enabled = true;
                obj.GetComponent<Bullet2>().enabled = false;
                obj.GetComponent<Bullet3>().enabled = false;
                GameObject obj2 = Instantiate(bullet, CurrentPos + offset2, Quaternion.identity) as GameObject;
                obj2.GetComponent<Bullet>().enabled = false;
                obj2.GetComponent<Bullet2>().enabled = true;
                GameObject obj3 = Instantiate(bullet, CurrentPos + offset3, Quaternion.identity) as GameObject;
                obj3.GetComponent<Bullet>().enabled = false;
                obj3.GetComponent<Bullet3>().enabled = true;
                bulletcount += 1;
            }
            else
            {
                Debug.Log("Fire!");
                Vector3 CurrentPos = ship.transform.position;
                Vector3 offset = new Vector3(0, 0, 3);
                GameObject obj = Instantiate(bullet, CurrentPos + offset, Quaternion.identity) as GameObject;
                obj.GetComponent<Bullet>().enabled = true;
                Destroy(obj.GetComponent<Bullet2>());
                Destroy(obj.GetComponent<Bullet3>());
                bulletcount += 1;
            }
        }
        if (ship.position.z <= -48.0f)
        {
            playsound();
            gameObject.SetActive(false);
            ParticleSystem part = Instantiate(exp, gameObject.transform.position, Quaternion.identity);
            Life.RestLife -= 1;
            rebirth = true;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            ship.AddForce(new Vector3(force, 0, 0), ForceMode.VelocityChange);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            ship.AddForce(new Vector3(-force, 0, 0), ForceMode.VelocityChange);
        }
        if (ship.position.x >= 68.0f)
        {
            bound.Set(68.0f, 1.5f, -43.0f);
            ship.MovePosition(bound);
        }
        if (ship.position.x <= -68.0f)
        {
            bound.Set(-68.0f, 1.5f, -43.0f);
            ship.MovePosition(bound);
        }
    }
    public void playsound()
    {
        AudioSource.PlayClipAtPoint(explode, MainCamera.transform.position);
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "EnemyBullet" && collisionInfo.collider.gameObject.GetComponent<EnemyBullet>().can_kill)
        {
            playsound();
            Debug.Log("ship collide!!!");
            gameObject.SetActive(false);
            ParticleSystem part = Instantiate(exp, gameObject.transform.position, Quaternion.identity);
            Life.RestLife -= 1;
            rebirth = true;
        }
    }
}
