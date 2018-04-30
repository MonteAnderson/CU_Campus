using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject player_vr;
    public GameObject player_fps;
    public GameObject teleport_destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {
        player_fps.transform.position = teleport_destination.transform.position;
        player_vr.transform.position = teleport_destination.transform.position;
        //Debug.Log("TELE2");
    }
}
