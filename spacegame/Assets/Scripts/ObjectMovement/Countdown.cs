using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public RocketBlast blast;
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    public IEnumerator StartCountdown() {
        text.enabled = true;
        int t = 10;
        while (t > - 1) {
            if (t == 0) {
                text.text = "BLAST OFF!!!";
            }
            else {
                text.text = "Countdown: " + t;
            }
            yield return new WaitForSeconds(1f);
            t--;
        }
        text.enabled = false;
        StartCoroutine(blast.blastOff());
    }
}
