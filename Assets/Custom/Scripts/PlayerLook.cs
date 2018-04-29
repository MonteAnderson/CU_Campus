using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    public string bookURL;
    public GameObject currentLookAtGameObject;
    public TextMesh playerCanvasText;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        /*GameObject newGameObjectBookURL = GameObject.Find("currentLookAtGameObject");
        PlayerLook playerScript = newGameObjectBookURL.GetComponent<PlayerLook>();
        playerScript.bookURL = bookURL;*/

        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);


        Debug.DrawRay(transform.position, fwd * 2, Color.white);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f, layerMask) && (hit.transform.tag == "Book"))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            //Debug.Log("Displaying Book Name: " + hit.transform.GetComponentInChildren<TextMesh>().text);
            Debug.Log(bookURL);

            currentLookAtGameObject = hit.transform.gameObject;
            playerCanvasText.text = "Interact to read '" + currentLookAtGameObject.GetComponent<textToBook>().book_name + "'";

            //bookURL = currentLookAtGameObject.GetComponent<PlayerLook>().bookURL;
            //Debug.Log(bookURL);

        }

        else
        {
            playerCanvasText.text = "";
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1f, Color.white);
            //Debug.Log("Did not Hit");
        }

        if ((Input.GetKeyDown(KeyCode.E)) || (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)))
        {
            Application.OpenURL(currentLookAtGameObject.GetComponent<textToBook>().book_url);
        }


        //Debug.Log(hit.transform.tag);
    }
}
