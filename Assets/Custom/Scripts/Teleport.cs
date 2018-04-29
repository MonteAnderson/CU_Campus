using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject player;
    public GameObject teleport_library;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("TELE");
        if (col.name == "Player")
        {
            player.transform.position = teleport_library.transform.position;
            Debug.Log("TELE2");
        }
    }
}
