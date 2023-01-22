using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start() {
        // Debug.Log("Here");
        GameObject ob = Instantiate(obj, new Vector3(obj.transform.position.x + 10, obj.transform.position.y, obj.transform.position.z + 10), obj.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
