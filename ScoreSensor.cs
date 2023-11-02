using System.Collections;
using System.Collections.Generic;
using RareCoders;
using UnityEngine;

public class ScoreSensor : MonoBehaviour
{
    public int scoreAmount = 1; // 通過ごとのスコア増加量

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreObject")) // タグが必要に応じて変更してください
        {
            UIController1.instance.score += scoreAmount;

            Debug.Log("通過"); //ログ表示
        }
    }
}
