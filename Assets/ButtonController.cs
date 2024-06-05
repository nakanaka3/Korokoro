using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Vector3 pressedScale = new Vector3(1, 0.5f, 1);
    private Vector3 originalScale;
    public AudioSource audioSource;
    public AudioClip buttonSound;

    private void Start()
    {
        originalScale = transform.localScale;

        // �{�^���̐F�𔖂��O���[�ɐݒ�
        GetComponent<Renderer>().material.color = new Color(0.75f, 0.75f, 0.75f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            transform.localScale = pressedScale;

            audioSource.PlayOneShot(buttonSound);

            // �{�^���̐F��Z���O���[�ɕύX
            GetComponent<Renderer>().material.color = new Color(0.33f, 0.33f, 0.33f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            transform.localScale = originalScale;
        }
    }
}