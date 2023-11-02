using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // 回転速度（度/秒）
    private float targetRotation = 0.0f;
    private float currentRotation = 0.0f;
    private bool isRotating = false;
    private float timer = 0.0f;
    public float rotationInterval = 10.0f;
    private bool hasStarted = false;
    private float RotationAngle;
    public int[] List;

    private void Start()
    {

    }

    private void Update()
    {
        if (!hasStarted)
        {
            timer += Time.deltaTime;
            if (timer >= rotationInterval)
            {
                StartRotation();
                hasStarted = true;
            }
        }

        if (isRotating)
        {
            // カメラをZ軸周りに回転させる
            currentRotation = Mathf.MoveTowardsAngle(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);

            // targetRotation に達したら回転を停止
            if (Mathf.Approximately(currentRotation, targetRotation))
            {
                StopRotation();
            }
        }
        else
        {
            // 時間を計測し、一定の時間経過後に回転を開始
            timer += Time.deltaTime;
            if (timer >= rotationInterval)
            {
                StartRotation();
            }
        }
    }

    private void StartRotation()
    {
        // ランダムに回転角度を選択
        RotationAngle = Random.Range(0, List.Length) * 45;
        targetRotation = Random.Range(0, 8) * RotationAngle;

        // 回転速度で回転を開始
        isRotating = true;

        // 回転角度のログを出力
        Debug.Log("Start Rotation: " + targetRotation);
    }

    private void StopRotation()
    {
        // 回転を停止し、タイマーをリセット
        isRotating = false;
        timer = 0.0f;
    }
}