using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textToBook : MonoBehaviour {

    public TextMesh book_title;
    public TextAsset book_content;
    private string book_url;
    private int i = 0;

	// Use this for initialization
	void Start () {
        
        book_title.text = book_content.name;
        book_url = book_content.text;

        /*
        if ((book_content.name.Length >= 18) && (i <= 18))
        {
            Debug.Log(i);
            book_title.text += book_content.name[i];
            i += 1;
        }*/

    }
	
	// Update is called once per frame
	void Update () {
        

    }
}
