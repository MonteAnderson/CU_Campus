using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    public GameObject player;
    public string bookURL;
    public GameObject currentLookAtGameObject;

    public TextMesh playerCanvasText;
    //public TextMesh bookSideText;

    // Use this for initialization
    void Start () {
        GameObject[] bookList = GameObject.FindGameObjectsWithTag("Book");

        foreach (GameObject book in bookList)
        {
            string[] bookData = book.name.Split('~');
            book.GetComponent<TextMesh>().text = bookData[0];
            //bookSideText.text = bookData[0];
        }
        
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
            string[] bookData = currentLookAtGameObject.name.Split('~');
            //currentLookAtGameObject.GetComponent<textToBook>.
            playerCanvasText.text = bookData[1];
            if ((Input.GetKeyDown(KeyCode.E)) || (OVRInput.Get(OVRInput.Button.Two)))
            {
                Application.OpenURL(bookData[2]);
            }
            //bookURL = currentLookAtGameObject.GetComponent<PlayerLook>().bookURL;
            //Debug.Log(bookURL);

        }

        else
        {
            playerCanvasText.text = "";
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1f, Color.white);
            //Debug.Log("Did not Hit");
        }



        if ((Input.GetKeyDown(KeyCode.R)) || OVRInput.Get(OVRInput.Button.One))
        {
            player.transform.position = new Vector3(0, 1, 0);
        }

        //Debug.Log(hit.transform.tag);
    }
}
