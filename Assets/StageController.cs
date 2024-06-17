using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiltStage : MonoBehaviour
{
    public float tiltSpeed = 20f;

    void Update()
    {
        // スマートフォンの傾きまたはPCの矢印キーの入力を取得
        float tiltX = (Input.acceleration.x + Input.GetAxis("Vertical")) * tiltSpeed;
        float tiltZ = (-Input.acceleration.y - Input.GetAxis("Horizontal")) * tiltSpeed;

        // 傾きをステージの回転に反映
        Vector3 rotation = new Vector3(tiltX, 0, tiltZ);
        Vector3 nextRotation = transform.eulerAngles + rotation * Time.deltaTime;

        // XとZの傾きが30度を超えないように制御
        if (nextRotation.x > 30f && nextRotation.x < 330f)
        {
            nextRotation.x = (nextRotation.x <= 180f) ? 30f : 330f;
        }
        if (nextRotation.z > 30f && nextRotation.z < 330f)
        {
            nextRotation.z = (nextRotation.z <= 180f) ? 30f : 330f;
        }

        // 傾きを更新
        transform.eulerAngles = nextRotation;
    }
}