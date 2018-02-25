using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController_MouseAndKeyboard : MonoBehaviour {

    public Rigidbody characterController_RigidBody;
    public GameObject cameraLook;
    public float walkspeed = 2;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 xyForward = new Vector3(cameraLook.transform.forward.x, 0, cameraLook.transform.forward.z);
        Vector3 negxyForward = new Vector3(-cameraLook.transform.forward.x, 0, -cameraLook.transform.forward.z);
        float horizontal = Input.GetAxis("Mouse X") * 4;

        if (Input.GetKey(KeyCode.W))
        {
            characterController_RigidBody.velocity += transform.forward / 10;
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterController_RigidBody.velocity -= transform.forward / 10;
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterController_RigidBody.velocity -= transform.right / 10;
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterController_RigidBody.velocity += transform.right / 10;
        }

    }
}
