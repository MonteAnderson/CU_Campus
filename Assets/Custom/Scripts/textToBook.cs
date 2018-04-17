using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textToBook : MonoBehaviour {

    public TextMesh book_title;
    public TextAsset book_content;

	// Use this for initialization
	void Start () {
        book_title.text = book_content.name;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
