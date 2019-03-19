using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalScore : MonoBehaviour
{
    public Text finalscoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalscoreText.text = Score.score.ToString("Your final score is:0");
    }
}
