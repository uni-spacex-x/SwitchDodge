using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RareCoders;

public class HighScoreText : MonoBehaviour
{
    public Text highScore;


    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<Text>();
        if (UIController1.instance != null)
        {
            highScore.text = UIController1.instance.highScore.ToString();
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
