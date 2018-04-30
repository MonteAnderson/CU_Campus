using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSelection : MonoBehaviour {

    public GameObject Player_VR;
    public GameObject Player_FPS;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1)))
        {
            Player_FPS.gameObject.SetActive(false);
            Player_VR.gameObject.SetActive(true);
        }

        if ((Input.GetKeyDown(KeyCode.Alpha2)))
        {
            Player_FPS.gameObject.SetActive(true);
            Player_VR.gameObject.SetActive(false);
        }


	}
}
