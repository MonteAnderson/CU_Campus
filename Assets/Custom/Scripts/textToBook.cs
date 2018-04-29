using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textToBook : MonoBehaviour {

    public TextMesh book_title;
    public TextAsset book_content;
    public string book_name;
    public string book_url;
    public string book_category;
    public Color book_color;
    public GameObject book;
    Material book_mat;


    private int i = 0;

	// Use this for initialization
	void Start () {
        book_title.text = book_name;
        book_mat = GetComponent<Renderer>().material;
        //book_title.text = book_content.name;
        //book_url = book_content.text;

        if (book_category == "nature")
        {
            book_mat.color = Color.red;
        }

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
