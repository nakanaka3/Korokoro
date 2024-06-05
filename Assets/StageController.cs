using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiltStage : MonoBehaviour
{
    public float tiltSpeed = 30f;

    void Update()
    {
        float tiltX = Input.GetAxis("Vertical") * tiltSpeed * Time.deltaTime;
        float tiltZ = -Input.GetAxis("Horizontal") * tiltSpeed * Time.deltaTime;

        Vector3 rotation = new Vector3(tiltX, 0, tiltZ);
        transform.Rotate(rotation);
    }
}