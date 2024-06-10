using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //（追加）
public class BallController : MonoBehaviour
{
    // 次に押すべきボタンの番号
    public static int nextButtonNumber = 1;
    public AudioSource audioSource;
    public AudioClip buttonSound;
    public AudioClip GateSound;

    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグを取得
        string currentTag = collision.gameObject.tag;
        // タグが次に押すべきボタンのタグと一致するかチェック
        if (currentTag == "Button" + nextButtonNumber)
        {
            // 一致したら、音を鳴らす
            audioSource.PlayOneShot(buttonSound);

            // Change the color of the button to show that it has been pressed
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
            renderer.material.color = Color.blue;

            // 一致したら、次に押すべきボタンの番号を更新
            nextButtonNumber++;
            // 全てのボタンを押し終わったら、何もしない
            if (nextButtonNumber > 6)
            {
                // 一致したら、音を鳴らす
                audioSource.PlayOneShot(GateSound);
            }
            // ボタンを押したことを表示（デバッグ用）
            Debug.Log("Pressed button: " + currentTag);
        }
    }
}



