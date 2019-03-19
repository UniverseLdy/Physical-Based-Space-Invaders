using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gm;
    public GameObject enemy;
    public GameObject Enemybullet;
    public GameObject MainCamera;
    public GameObject Deadbody;
    public Rigidbody Enemies;
    public Vector3 sidewaylength = new Vector3(6.5f, 0, 0);
    public Vector3 depthlength = new Vector3(0, 0, -5);
    public AudioClip explode;
    public Quaternion Q;
    public int direction;
    private float current_time;
    private float last_time;
    private int depth_count;
    private float fire_time_current, fire_time_last, fire_time_interval;
    private float add;
    // Start is called before the first frame update
    void Start()
    {
        fire_time_last =  last_time = Time.time;
        fire_time_interval = Random.Range(0, 8.0f);
        Q = gameObject.transform.rotation;
        add = 0.0f;
        depth_count = 4;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        current_time = Time.time;
        fire_time_current = Time.time;
        if(current_time - last_time >= (1.5 -add))
        {
            //Debug.Log("Enemy move");
            Enemies.transform.position += (sidewaylength* direction);
            last_time = current_time;
            add += 0.035f;
            depth_count += 1;
        }
        if(depth_count == 8)
        {
            //Debug.Log("Enemy move down");
            gameObject.transform.position += (depthlength);
            direction *= -1;
            depth_count = 0;
        }
        if (fire_time_current - fire_time_last >= fire_time_interval& GameManager.firecount<=3)
        {
            Debug.Log("Enemy Fire!");
            Vector3 CurrentPos = gameObject.transform.position;
            Vector3 offset = new Vector3(0, 0, 0);
            GameObject obj = Instantiate(Enemybullet, CurrentPos + offset, Quaternion.identity) as GameObject;
            EnemyBullet b = obj.GetComponent<EnemyBullet>();
            fire_time_interval = fire_time_interval = Random.Range(0, 8.0f);
            fire_time_last = fire_time_current;
            GameManager.firecount +=1;
        }
        if(gameObject.transform.position.z <= -46.0f)
        {
            gm.GameOver();
        }

    }
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bullet"|| collisionInfo.collider.tag == "Deadbody")
        {
            //AudioSource.PlayClipAtPoint(explode, gameObject.transform.position);
            Debug.Log("play sound");
            Vector3 CurrentPos = gameObject.transform.position;
            GameObject obj = Instantiate(Deadbody, CurrentPos, Q) as GameObject;
            DeadBody d = obj.GetComponent<DeadBody>();
            gameObject.SetActive(false);
            GameManager.enemy_count -= 1;
        }
    }
    public void playsound()
    {
        AudioSource.PlayClipAtPoint(explode, MainCamera.transform.position);
    }
}
