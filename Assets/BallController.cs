using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //�i�ǉ��j
public class BallController : MonoBehaviour
{
    // ���ɉ����ׂ��{�^���̔ԍ�
    public static int nextButtonNumber = 1;
    public AudioSource audioSource;
    public AudioClip buttonSound;
    public AudioClip GateSound;

    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O���擾
        string currentTag = collision.gameObject.tag;
        // �^�O�����ɉ����ׂ��{�^���̃^�O�ƈ�v���邩�`�F�b�N
        if (currentTag == "Button" + nextButtonNumber)
        {
            // ��v������A����炷
            audioSource.PlayOneShot(buttonSound);

            // Change the color of the button to show that it has been pressed
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
            renderer.material.color = Color.blue;

            // ��v������A���ɉ����ׂ��{�^���̔ԍ����X�V
            nextButtonNumber++;
            // �S�Ẵ{�^���������I�������A�������Ȃ�
            if (nextButtonNumber > 6)
            {
                // ��v������A����炷
                audioSource.PlayOneShot(GateSound);
            }
            // �{�^�������������Ƃ�\���i�f�o�b�O�p�j
            Debug.Log("Pressed button: " + currentTag);
        }
    }
}



