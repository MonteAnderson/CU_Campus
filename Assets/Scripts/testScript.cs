using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testScript : MonoBehaviour {


    public double test = 0;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		while (test <= 60){
            Debug.Log(test);
            test += 1;
        }
	}
}
