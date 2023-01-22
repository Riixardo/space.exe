using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchdown : MonoBehaviour
{

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            touchdown();
        }
    }
    void touchdown() {
        Debug.Log("TOUUCHDOWN");
    }
}
