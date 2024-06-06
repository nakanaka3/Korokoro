using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public GameObject gate; // Set this in the inspector


    void Update()
    {
        if (BallController.nextButtonNumber > 6)
        {
            gate.SetActive(false); // This will disable the gate, making it disappear

            // ゲートが開いたことを表示（デバッグ用）
            Debug.Log("Gate Open");
        }
    }
}
