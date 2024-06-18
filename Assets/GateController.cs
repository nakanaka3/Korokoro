using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  //（追加）

public class GateController : MonoBehaviour
{
    public GameObject gate; // Set this in the inspector
    public Collider gateCollider; // ゲートの物理的な障害物のコライダーを参照します

    //ゲーム終了時に表示するテキスト（追加）
    private GameObject stateText;

    public AudioSource audioSource;
    public AudioClip GoalSound;
    public bool isClear = false;

    private void Start()
    {
        //シーン中のstateTextオブジェクトを取得（追加）
        this.stateText = GameObject.Find("GameResultText");
    }

    void Update()
    {
        if (BallController.nextButtonNumber > 6)
        {
            Vector3 scale = transform.localScale;
            scale.z *= 0.001f; //  Z軸方向に0.001に小さくする。
            transform.localScale = scale;//壁沿いにあたっても反応してしまうので。
            // Open the gate
            gate.GetComponent<MeshRenderer>().enabled = false; // ゲートの見た目を消します
            // ゲートのコライダーをトリガーに変更します
            gateCollider.isTrigger = true;

            // ゲートが開いたことを表示（デバッグ用）
            Debug.Log("Gate Open");
        }
        else
        {
            gate.GetComponent<MeshRenderer>().enabled = true; // ゲートの見た目を戻します
            gateCollider.enabled = true; // ゲートの物理的な障害物のコライダーを有効化します
        }
        // もし音が鳴った場合
        if ((isClear == true) && (Input.GetMouseButtonDown(0))) // マウスの左クリックを検出
        {
                Time.timeScale = 1; // 時間の流れを元に戻す
                //SampleSceneを読み込む（追加）
                SceneManager.LoadScene("2ndStage");
                BallController.nextButtonNumber = 1;
                gate.GetComponent<MeshRenderer>().enabled = true; // ゲートの見た目を戻します
                gateCollider.enabled = true; // ゲートの物理的な障害物のコライダーを有効化します
        }
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Clear");
            //stateTextにGAME CLEARを表示（追加）
            this.stateText.GetComponent<Text>().text = "Clear!!";

            isClear = true;

            // 一致したら、音を鳴らす
            audioSource.PlayOneShot(GoalSound);
            Time.timeScale = 0; // 時間を止める（フリーズ）

        }
    }
}
