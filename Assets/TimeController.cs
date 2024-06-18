using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // シーン管理をするために必要

public class Timecontroller : MonoBehaviour
{
    public float timeStart = 40f;
    public Text textBox;
    public bool isGameOver = false;

    //ゲーム終了時に表示するテキスト（追加）
    private GameObject stateText;

    void Start()
    {
        textBox.text = timeStart.ToString("F1");

        //シーン中のstateTextオブジェクトを取得（追加）
        this.stateText = GameObject.Find("GameResultText");
    }

    void Update()
    {

        timeStart -= Time.deltaTime;
        textBox.text = (Mathf.Round(timeStart * 10f) / 10f).ToString("F1");

        if (timeStart <= 0)
        {
            //stateTextにGAME OVERを表示（追加）
            this.stateText.GetComponent<Text>().text = "Game Over";
            // 時間の表示を消す
            textBox.text = "";

            Debug.Log("Game Over");

            isGameOver = true;

            Time.timeScale = 0; // 時間を止める（フリーズ）
        }

        if (isGameOver == true)
        {
            if (Input.GetMouseButtonDown(0)) // マウスの左クリックを検出
            {
                Time.timeScale = 1; // 時間の流れを元に戻す
                //SampleSceneを読み込む（追加）
                SceneManager.LoadScene("1stStage");
                BallController.nextButtonNumber = 1;
            }
        }
    }
}