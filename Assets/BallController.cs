using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // 次に押すべきボタンの番号
    private int nextButtonNumber = 1;

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグを取得
        string currentTag = collision.gameObject.tag;

        // タグが次に押すべきボタンのタグと一致するかチェック
        if (currentTag == "Button" + nextButtonNumber)
        {
            // 一致したら、次に押すべきボタンの番号を更新
            nextButtonNumber++;

            // 全てのボタンを押し終わったら、次の番号を1にリセット
            if (nextButtonNumber > 6)
            {
                nextButtonNumber = 1;
            }

            // ボタンを押したことを表示（デバッグ用）
            Debug.Log("Pressed button: " + currentTag);
        }
    }
}