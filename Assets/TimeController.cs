using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // �V�[���Ǘ������邽�߂ɕK�v

public class Timecontroller : MonoBehaviour
{
    public float timeStart = 40f;
    public Text textBox;
    public bool isGameOver = false;

    //�Q�[���I�����ɕ\������e�L�X�g�i�ǉ��j
    private GameObject stateText;

    void Start()
    {
        textBox.text = timeStart.ToString("F1");

        //�V�[������stateText�I�u�W�F�N�g���擾�i�ǉ��j
        this.stateText = GameObject.Find("GameResultText");
    }

    void Update()
    {

        timeStart -= Time.deltaTime;
        textBox.text = (Mathf.Round(timeStart * 10f) / 10f).ToString("F1");

        if (timeStart <= 0)
        {
            //stateText��GAME OVER��\���i�ǉ��j
            this.stateText.GetComponent<Text>().text = "Game Over";
            // ���Ԃ̕\��������
            textBox.text = "";

            Debug.Log("Game Over");

            isGameOver = true;

            Time.timeScale = 0; // ���Ԃ��~�߂�i�t���[�Y�j
        }

        if (isGameOver == true)
        {
            if (Input.GetMouseButtonDown(0)) // �}�E�X�̍��N���b�N�����o
            {
                Time.timeScale = 1; // ���Ԃ̗�������ɖ߂�
                //SampleScene��ǂݍ��ށi�ǉ��j
                SceneManager.LoadScene("1stStage");
                BallController.nextButtonNumber = 1;
            }
        }
    }
}