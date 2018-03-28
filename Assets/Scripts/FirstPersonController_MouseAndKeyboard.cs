using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController_MouseAndKeyboard : MonoBehaviour {

    public Rigidbody characterController_RigidBody;
    public GameObject cameraLook;
    public float walkspeed = 2;
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 5F;
    public float sensitivityY = 5F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 xyForward = new Vector3(cameraLook.transform.forward.x, 0, cameraLook.transform.forward.z);
        Vector3 negxyForward = new Vector3(-cameraLook.transform.forward.x, 0, -cameraLook.transform.forward.z);

        //cameraLook.transform.Rotate(Input.mousePosition("X"));

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
