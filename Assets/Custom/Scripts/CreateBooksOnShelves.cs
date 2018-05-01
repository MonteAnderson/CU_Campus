﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CULibrary
{
    public class CreateBooksOnShelves : MonoBehaviour
    {
        public GameObject baseBookGameObject;
        public GameObject basePlayerGameObject;
        public GameObject baseMainFloorGameObject;
        public GameObject baseUpperFloorGameObject;

        private List<Floor> floors = new List<Floor>();
        private List<Book> books = new List<Book>();

        public Material Material_Book_White;
        public Material Material_Book_Red;

        //public TextMesh bookText;

        // Use this for initialization
        void Start()
        {
            TextAsset databaseData = Resources.Load<TextAsset>("database_small");
            string[] data = databaseData.text.Split(new char[] { '\n' });

            //Debug.Log(data.Length);
            // set base game object references
            Floor.baseMainFloorGameObject = baseMainFloorGameObject;
            Floor.baseUpperFloorGameObject = baseUpperFloorGameObject;
            Book.baseBookGameObject = baseBookGameObject;

            // update player 
            resetPlayerPosition();

            // generate book list
            for (int i = 0; i < 1; i++)
            {
                string bookName = "";
                string bookURL = "";
                string bookCategory = "";
                //books.Add(new Book("History", "Apollo 11", "Apollo 11", "https://en.wikipedia.org/wiki/Apollo_11"));
                for (int j = 0; j < data.Length; j++)
                {
                    string[] row = data[j].Split(new char[] { ',' });
                    bookCategory = row[0];
                    bookName = row[1];
                    bookURL = row[2];
                    //bookText.text = bookName;
                    Debug.Log(bookName);
                    Debug.Log("Category: " + bookCategory + " | Name: " + bookName + " | URL: " + bookURL);
                    books.Add(new Book(bookCategory, bookName, bookName, bookURL));
                }
                //Debug.Log(data[i]);
                //books.Add(new Book(data[i], bookName, bookName, bookURL));
                //books.Add(new Book(bookCategory, bookName, bookName, bookURL));
            }
            


            // create library based on book list
            createLibrary();
        }

        // Update is called once per frame
        void resetPlayerPosition()
        {
            basePlayerGameObject.transform.position = new Vector3(0, 2.0f, 0);
        }

        void createLibrary()
        {
            // compute number of additional floors given results size 
            int numFloors = books.Count / Constants.TOTAL_BOOKS_PER_FLOOR;
            if (numFloors == 0 || books.Count % Constants.TOTAL_BOOKS_PER_FLOOR != 0)
            {
                numFloors++;
            }
            
            // create floor instances
            int startIndex;
            int endIndex = 0;
            for (int i = 0; i < numFloors; i++)
            {
                startIndex = endIndex;
                if (startIndex + Constants.TOTAL_BOOKS_PER_FLOOR >= books.Count)
                    endIndex = books.Count;
                else
                    endIndex = startIndex + Constants.TOTAL_BOOKS_PER_FLOOR;

                floors.Add(new Floor(i,
                                     books.GetRange(startIndex,
                                                    endIndex - startIndex)));
            }
        }
    }
}