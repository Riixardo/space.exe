using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float timeAlive;
    public Vector3 dir;
    public float speed = 10f;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position += transform.right * 0.25f;
        transform.position -= transform.up * 0.16f;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(dir * Time.deltaTime * 2f);
        // Debug.Log(timeAlive);
        transform.position += transform.forward * Time.deltaTime * speed;
        timeAlive += 1/30f;
        if (timeAlive >= 30) {
            Destroy(gameObject);
        }  
    }
}
