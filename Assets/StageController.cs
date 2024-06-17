using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiltStage : MonoBehaviour
{
    public float tiltSpeed = 20f;

    void Update()
    {
        // �X�}�[�g�t�H���̌X���܂���PC�̖��L�[�̓��͂��擾
        float tiltX = (Input.acceleration.x + Input.GetAxis("Vertical")) * tiltSpeed;
        float tiltZ = (-Input.acceleration.y - Input.GetAxis("Horizontal")) * tiltSpeed;

        // �X�����X�e�[�W�̉�]�ɔ��f
        Vector3 rotation = new Vector3(tiltX, 0, tiltZ);
        Vector3 nextRotation = transform.eulerAngles + rotation * Time.deltaTime;

        // X��Z�̌X����30�x�𒴂��Ȃ��悤�ɐ���
        if (nextRotation.x > 30f && nextRotation.x < 330f)
        {
            nextRotation.x = (nextRotation.x <= 180f) ? 30f : 330f;
        }
        if (nextRotation.z > 30f && nextRotation.z < 330f)
        {
            nextRotation.z = (nextRotation.z <= 180f) ? 30f : 330f;
        }

        // �X�����X�V
        transform.eulerAngles = nextRotation;
    }
}