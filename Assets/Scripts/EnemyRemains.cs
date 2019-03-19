using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRemains : MonoBehaviour
{
    // Start is called before the first frame update
    public Text EnemyText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyText.text = GameManager.enemy_count.ToString("Enemy:0");
    }
}
