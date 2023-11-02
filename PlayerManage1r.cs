using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンの切り替えに必要
using RareCoders;


namespace RareCoders
{

    public class PlayerManager1 : MonoBehaviour
    {
        #region Private Variables
        private float currentPosition;
        public float speed;
        public float maxSpeed = 5f;
        public float Speedrevel = 0.01f;
        WaitForSeconds _waitTime;
        Coroutine speedCoroutine;
        Vector3 _scale;
        Vector3 _position;
        public GameObject crashEffect;

        [SerializeField]
        private AudioSource sound01;

        [SerializeField]
        private AudioClip b1;

        [SerializeField]
        float colorLerpDuration;

        [SerializeField]
        private GameObject StartPanel;

        private bool gameStarted = true;

        Camera _cam;

        #endregion

        // ゲームオブジェクトが有効になったときに呼ばれるメソッド
        private void OnEnable()
        {
            _cam = Camera.main;

            // スタートシーンから移動してきた場合、ゲームが開始していない場合にのみ開始処理を実行
            if (!TheGlobals1.playingMode)
            {
                gameStarted = false;
            }

            _waitTime = new WaitForSeconds(1f);
            Debug.Log("OnEnble");
        }

        private void Start()
        {
            UIController1.instance.score = 0;

            StartPanel.SetActive(true);
        }

        private void StartGame()
        {
            // ゲーム開始に必要な初期化や設定を行う
            TheGlobals1.playingMode = true; // ゲームを開始モードに設定

            Time.timeScale = 1;

            gameStarted = true; // ゲームが開始されたことをフラグで示す
        }

        // 毎フレーム呼ばれるメソッド
        private void Update()
        {
            if (!gameStarted)
            {
                // ゲームが開始されていない場合、1度目のInputでStartGame()メソッドを呼び出す
                if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
                {
                    StartGame();

                    StartPanel.SetActive(false);
                }
            }
            else
            {
                // ゲームが開始された後、2度目以降のInputでプレイヤーの操作を検出
                DetectInput();
            }
        }

        // 衝突が発生したときに呼ばれるメソッド
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject collidedObject = collision.gameObject;

            if (collidedObject.CompareTag("ScoreObject"))
            {
                Invoke("Timestop", 1);

                this.gameObject.SetActive(false);

                crashEffect.transform.position = this.transform.position;

                crashEffect.SetActive(true);

                UIController1 uiController = FindObjectOfType<UIController1>();
                if (uiController != null)
                {
                    uiController.SoundPlayer();
                }

                Debug.Log("衝突");
            }
        }

        void Timestop()
        {
            Time.timeScale = 0;

            Debug.Log("停止");

            SceneManager.LoadScene("ResultScenes");

            TheGlobals1.playingMode = false;
        }
        
        

        // プレイヤーの操作を検出するメソッド
        void DetectInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InversePlayer();

                sound01.PlayOneShot(b1);
            }
        }

        // プレイヤーの向きを反転させるメソッド
        void InversePlayer()
        {
            _scale = transform.localScale;
            _position = transform.position;
            _scale.x = _scale.x * -1;
            _position.x = _position.x * -1;
            transform.localScale = _scale;
            transform.localPosition = _position;
        }

        // プレイヤーの速度を増加させるメソッド
        public void SpeedIncrement()
        {
            speedCoroutine = StartCoroutine(speedManager());
        }

        // 速度増加を停止するメソッド
        public void StopIncrement()
        {
            StopCoroutine(speedCoroutine);
        }

        // 速度を管理するコルーチン
        IEnumerator speedManager()
        {
            yield return _waitTime;

            if (speed < maxSpeed)
            {
                speed += Speedrevel;
            }
            Debug.Log("Playing Mode " + TheGlobals1.playingMode);

            if (TheGlobals1.playingMode)
            {
                speedCoroutine = StartCoroutine(speedManager());
            }
        }
    }
}