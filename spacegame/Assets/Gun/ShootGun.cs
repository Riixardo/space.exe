using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gun;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 pos = transform.position;
            // pos.Translate(pos.forward.x.normalize)

            // Debug.Log(pos);
            // Debug.Log(pos + 2f * gun.transform.position);
            GameObject clone = Instantiate(projectile, pos + transform.forward * 0.8f, gun.transform.rotation);
            // clone.set_gun(this);
        }
    }
}
