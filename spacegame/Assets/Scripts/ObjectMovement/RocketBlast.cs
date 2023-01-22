using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketBlast : MonoBehaviour
{
    public Transform rocket;
    public TextMeshProUGUI text;

    public IEnumerator blastOff() {
        float t = 0f;
        float touchdownTimer = 0f;
        float exposure = 1f;
        while (true) {
            t += 0.2f;
            if (t >= 24) {
                exposure -= 0.01f;
                RenderSettings.skybox.SetFloat("_Exposure", exposure);
            }
            if (exposure <= 0.1f) {
                t = 1f;
                RenderSettings.skybox.SetFloat("_Exposure", 0f);
                touchdownTimer += 0.2f;
                if (touchdownTimer >= 20f) {
                    text.enabled = true;
                    text.GetComponent<Touchdown>().enabled = true;
                }
            }
            rocket.Translate(0, Mathf.Clamp(t, 0, 25f), 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
