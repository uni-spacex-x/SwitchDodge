using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RareCoders
{
    public class ObstacleMover1 : MonoBehaviour
    {
        private float currentPosition;
        public float speed;
        private float timeSinceLastSpeedChange;
        public float speedChangeInterval = 20f; // スピード変更の間隔（20秒）
        public float Speedrevel = -0.2f;

        UIController1 _UIController;

        private void OnEnable()
        {
            _UIController = FindObjectOfType<UIController1>();
        }

        void Start()
        {
            timeSinceLastSpeedChange = 0f; // 初回の速度変更までの時間を0に設定
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (TheGlobals1.playingMode)
            {
                currentPosition = transform.localPosition.y;
                currentPosition = currentPosition + Time.deltaTime * speed;
                transform.localPosition = new Vector3(transform.localPosition.x, currentPosition, transform.localPosition.z);

                // 時間の経過を監視し、一定の間隔で速度を変更
                timeSinceLastSpeedChange += Time.deltaTime;
                if (timeSinceLastSpeedChange >= speedChangeInterval)
                {
                    // 20秒ごとに速度を増加させる
                    speed += Speedrevel;
                    timeSinceLastSpeedChange = 0f; // タイマーリセット

                    // 速度情報をデバッグコンソールに表示
                    Debug.Log("Speed increased to: " + speed);

                }
            }
        }
    }
}