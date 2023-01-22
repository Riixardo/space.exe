using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touchdown : MonoBehaviour
{

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            touchdown();
        }
    }
    void touchdown() {
        SceneManager.LoadScene("Mars");
    }
}
