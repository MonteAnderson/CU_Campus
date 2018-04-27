using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AIWalking : MonoBehaviour
{
    public Transform NPC_destination_1;
    public Transform NPC_destination_2;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //GlobalTime currentTime = TimeKeeping_Object.GetComponent<GlobalTime>();
        
        if (transform.position != NPC_destination_1.transform.position)
        {
            transform.GetComponent<NavMeshAgent>().destination = NPC_destination_2.position;
        }

        if (transform.position == NPC_destination_1.transform.position)
        {
            transform.GetComponent<NavMeshAgent>().destination = NPC_destination_1.position;
        }
    }
}
