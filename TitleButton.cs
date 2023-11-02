using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンの切り替えに必要

public class TitleButton : MonoBehaviour
{
    // ボタンがクリックされた際に呼び出される関数
    public void LoadScene()
    {
        SceneManager.LoadScene("TitleScenes");
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
