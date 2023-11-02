using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RareCoders
{
    public class UIController1 : MonoBehaviour
    {
        public static UIController1 instance = null;

        public int score;
        public int highScore;

        [SerializeField]
        Text HighScoreText;

        [SerializeField]
        private AudioSource sound001;

        [SerializeField]
        private AudioClip b2;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }

            else
            {
                Destroy(this.gameObject);
            }

        }

        private void Start()
        {
            //ハイスコアの初期値を取得
            highScore = PlayerPrefs.GetInt("SCORE", 0);
        }

        private void Update()
        {
            if (highScore < score)
            {
                highScore = score;

                PlayerPrefs.SetInt("SCORE", highScore);
                PlayerPrefs.Save();

                Debug.Log("ハイスコアを上回りました。");
            }
        }

        public void SoundPlayer()
        {
            sound001.PlayOneShot(b2);
        }

    }
}