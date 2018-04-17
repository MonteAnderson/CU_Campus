using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testScript : MonoBehaviour {

    public GameObject this_ball;

    public double test = 0;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        this_ball.transform.position += this_ball.transform.forward / 50;



		while (test <= 60){
            Debug.Log(test);
            test += 1;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
