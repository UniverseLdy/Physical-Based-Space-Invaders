using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public int firecount;
    private float UFO_time_current, UFO_time_last, UFO_time_interval;
    public GameObject UFO;
    public GameObject spaceship;
    static public bool UFO_count;
    static public int enemy_count;
    static public int direction;
    public float current;
    // Start is called before the first frame update
    void Start()
    {
        enemy_count = 60;
        firecount = 0;
        UFO_time_last = Time.time;
        UFO_time_interval = Random.Range(7.5f, 10.0f);
        UFO_count = true;
        direction = 1;
        current = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        UFO_time_current = Time.time;
        if (UFO_time_current - UFO_time_last >= UFO_time_interval & UFO_count == true)
        {
            GameObject obj = Instantiate(UFO, new Vector3 (63,1.5f,40), Quaternion.identity) as GameObject;
            UFO b = obj.GetComponent<UFO>();
            UFO_time_interval = UFO_time_interval = Random.Range(5.0f, 10.0f);
            UFO_time_last = UFO_time_current;
            UFO_count = false;
        }
        if(spaceship.GetComponent<Spaceship>().rebirth)
        {
            current += Time.deltaTime;
        }
        if (Life.RestLife > 0 && current >= 1.2f)
        {
            spaceship.SetActive(true);
            spaceship.transform.position = new Vector3(0.0f, 2.0f, -43.0f);
            spaceship.GetComponent<Spaceship>().rebirth = false;
            current = 0.0f;
        }
        if (Life.RestLife == 0)
        {
            GameOver();
            spaceship.GetComponent<Spaceship>().rebirth = false;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("End Scene");
    }
}
