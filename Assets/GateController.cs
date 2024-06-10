using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //�i�ǉ��j

public class GateController : MonoBehaviour
{
    public GameObject gate; // Set this in the inspector
    public Collider gateCollider; // �Q�[�g�̕����I�ȏ�Q���̃R���C�_�[���Q�Ƃ��܂�

    //�Q�[���I�����ɕ\������e�L�X�g�i�ǉ��j
    private GameObject stateText;

    public AudioSource audioSource;
    public AudioClip GoalSound;


    private void Start()
    {
        //�V�[������stateText�I�u�W�F�N�g���擾�i�ǉ��j
        this.stateText = GameObject.Find("GameResultText");
    }

    void Update()
    {
        if (BallController.nextButtonNumber > 6)
        {
            Vector3 scale = transform.localScale;
            scale.z *= 0.001f; // ���݂̃X�P�[����1/5�ɂ��܂�
            transform.localScale = scale;// Z��������0.001�ɏ���������B�ǉ����ɂ������Ă��������Ă��܂��̂ŁB
            // Open the gate
            gate.GetComponent<MeshRenderer>().enabled = false; // �Q�[�g�̌����ڂ������܂�
            // �Q�[�g�̃R���C�_�[���g���K�[�ɕύX���܂�
            gateCollider.isTrigger = true;

            // �Q�[�g���J�������Ƃ�\���i�f�o�b�O�p�j
            Debug.Log("Gate Open");
        }
        else
        {
            gate.GetComponent<MeshRenderer>().enabled = true; // �Q�[�g�̌����ڂ�߂��܂�
            gateCollider.enabled = true; // �Q�[�g�̕����I�ȏ�Q���̃R���C�_�[��L�������܂�
        }
    }

    //�g���K�[���[�h�ő��̃I�u�W�F�N�g�ƐڐG�����ꍇ�̏���
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Clear");
            //stateText��GAME CLEAR��\���i�ǉ��j
            this.stateText.GetComponent<Text>().text = "CLEAR!!";

            // ��v������A����炷
            audioSource.PlayOneShot(GoalSound);
        }
    }
}
