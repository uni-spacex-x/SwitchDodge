using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンの切り替えに必要

public class RetryButton : MonoBehaviour
{
    // ボタンがクリックされた際に呼び出される関数
    public void LoadScene()
    {
        // "PlayScene" という名前のシーンをロードする
        SceneManager.LoadScene("Gameplay 1");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
