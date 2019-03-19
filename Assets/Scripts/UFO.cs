using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainCamera;
    public AudioClip explode;
    public Vector3 thrust = new Vector3(-400.0f, 0, 0);
    public GameObject Deadbody;
    public Quaternion Q;
    private float last_time, current_time;
    void Start()
    {
        last_time = Time.time;
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
        Q = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        current_time = Time.time;
        if(current_time - last_time >= 5.5f)
        {
            Destroy(gameObject);
            GameManager.UFO_count = true;
        }
    }
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bullet")
        {
            Vector3 CurrentPos = gameObject.transform.position;
            GameObject obj = Instantiate(Deadbody, CurrentPos, Q) as GameObject;
            DeadBody d = obj.GetComponent<DeadBody>();
            Destroy(gameObject);
            Score.score += 200;
        }
    }
    public void playsound()
    {
        AudioSource.PlayClipAtPoint(explode, MainCamera.transform.position);
    }
}
