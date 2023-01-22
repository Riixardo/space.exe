using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChairMove : MonoBehaviour
{
    public TextMeshProUGUI text, text2;
    public GameObject player;
    public Transform end1, end2;

    bool oneTime = false;
    bool inZone = false;
    bool down = false;
    public bool ROCKETTIME = false;

    void Update() {

        bool onChai = player.GetComponent<FPMovement>().onChair;

        if (onChai && !oneTime) {
            text.enabled = false;
            oneTime = true;
            StartCoroutine(chairUp());
        }
        else if (!onChai && oneTime) {
            text.enabled = true;
            oneTime = false;
            Debug.Log("dwdwdwdwd");
            
        }
        if (inZone && Input.GetKeyDown("e") && !onChai) {
            player.GetComponent<FPMovement>().onChair = true;
            player.transform.parent = this.transform;
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.Rotate(0, 90f, 0);
            //player.transform.Translate(0, 0, -0.3f);
            player.transform.position = transform.position;
            ROCKETTIME = true;
            down = false;
        }
        if (!ROCKETTIME && Input.GetKeyDown("e") && onChai && !down) {
            StartCoroutine(chairDown());
            down = true;
        }
    }
    void OnTriggerEnter() {
        text.enabled = true;
        inZone = true;
    }
    void OnTriggerExit() {
        text.enabled = false;
        inZone = false;
    }
    IEnumerator chairUp() {
        while ((end1.position - transform.position).magnitude > 0.3f) {
            transform.position += new Vector3(0, 1f, 0) * 0.05f;
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(text2.GetComponent<Countdown>().StartCountdown());
    }
    IEnumerator chairDown() {
        while ((end2.position - transform.position).magnitude > 0.3f) {
            transform.position -= new Vector3(0, 1f, 0) * 0.05f;
            yield return new WaitForSeconds(0.02f);
        }
        player.GetComponent<FPMovement>().onChair = false;
        player.transform.parent = null;
        player.GetComponent<CharacterController>().enabled = true;
        player.transform.Rotate(0, -90f, 0);
        player.transform.Translate(0, 0, 0.3f);
    }
}
