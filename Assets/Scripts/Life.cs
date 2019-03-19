using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
    static public int RestLife;
    public Text rltext;
    // Start is called before the first frame update
    void Start()
    {
        RestLife = 3;
    }

    // Update is called once per frame
    void Update()
    {
        rltext.text = RestLife.ToString("Life:0");
    }
}
