using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public RocketBlast blast;
    public AudioSource s;
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    public IEnumerator StartCountdown() {
        text.enabled = true;
        s.Play();
        int t = 14;
        while (t > - 1) {
            if (t == 0) {
                text.text = "BLAST OFF!!!";
            }
            else if(t <= 10) {
                text.text = "Countdown: " + t;
            }
            yield return new WaitForSeconds(1f);
            t--;
        }
        text.enabled = false;
        StartCoroutine(blast.blastOff());
    }
}
