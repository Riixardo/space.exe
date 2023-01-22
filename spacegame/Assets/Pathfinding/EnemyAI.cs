using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    public GameObject self;
    private float DETECT_RADIUS = 5f;
    private float NEAR = 1f;
    private Vector3 initialPos;
    private List<Vector3> patrols;

    public Transform patrolBegin;
    public Transform patrolEnd;

    private int patrolState;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = self.transform.position;

        // If patrolBegin and patrolEnd is not null, then
        // we initialize it to some value depending on the displacement vector
        // if (patrolBegin == Vector3.zero) {
        //     patrolBegin = patrolEnd = initialPos;
        //     Vector3 displacementVector = new Vector3(5, 0, 0);
        //     patrolBegin -= displacementVector;
        //     patrolEnd += displacementVector;
        // }

        patrols = new List<Vector3>() {patrolBegin.position, patrolEnd.position};
        patrolState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, self.transform.position) < DETECT_RADIUS)
        {
            Debug.Log(Vector3.Distance(player.transform.position, self.transform.position));
            agent.SetDestination(player.transform.position);
            self.GetComponent<Renderer>().material.color = Color.red;
        } else {
            // Patrolling state
            agent.SetDestination(patrols[patrolState]);
            if (Vector3.Distance(self.transform.position, patrols[patrolState]) < NEAR) {
                agent.SetDestination(patrols[patrolState]);
                if (patrolState == 0) patrolState = 1;
                else patrolState = 0;
            }
            self.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }

}
