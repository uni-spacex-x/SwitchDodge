using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RareCoders;

public class ScoreText : MonoBehaviour
{
    public Text scoreText; // スコアを表示するテキストUI
    private int oldscore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        if (UIController1.instance != null)
        {
            scoreText.text = UIController1.instance.score.ToString();
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(oldscore != UIController1.instance.score)
        {
            scoreText.text = UIController1.instance.score.ToString();
            oldscore = UIController1.instance.score;
        }
    }

}
