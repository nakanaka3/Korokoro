using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallController : MonoBehaviour
{
    // ���ɉ����ׂ��{�^���̔ԍ�
    private int nextButtonNumber = 1;
    public AudioSource audioSource;
    public AudioClip buttonSound;
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
            // �S�Ẵ{�^���������I�������A���̔ԍ���1�Ƀ��Z�b�g
            if (nextButtonNumber > 6)
            {
                nextButtonNumber = 1;
            }
            // �{�^�������������Ƃ�\���i�f�o�b�O�p�j
            Debug.Log("Pressed button: " + currentTag);
        }
    }
}



