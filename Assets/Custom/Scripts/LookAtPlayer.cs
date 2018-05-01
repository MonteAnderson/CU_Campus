using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    public GameObject thisObject;
    public GameObject player_vr;
    //public GameObject player_fps;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //thisObject.transform.LookAt(player.transform.position);
        thisObject.transform.rotation = Quaternion.LookRotation(thisObject.transform.position - player_vr.transform.position);
        //thisObject.transform.rotation = Quaternion.LookRotation(thisObject.transform.position - player_fps.transform.position);
    }
}
