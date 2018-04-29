using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CULibrary
{
    public class Floor
    {
        public static GameObject baseEvenFloorGameObject;
        public static GameObject baseOddFloorGameObject;

        private const float FLOOR_HEIGHT = 3.8f;

        private int floorIndex;
        private float pos_y;
        private bool isEven;
        private GameObject floorObj;
        private List<Book> books = new List<Book>();
        private List<Bookshelf> bookshelves = new List<Bookshelf>();

        public Floor(int floorIndex, List<Book> books)
        {
            // intialize floor
            this.floorIndex = floorIndex;
            this.pos_y = floorIndex * FLOOR_HEIGHT;

            // instantiate alternating floor plan based on even or odd floor index
            if (floorIndex % 2 == 0)
            {
                this.floorObj = UnityEngine.Object.Instantiate(baseEvenFloorGameObject); 
            }
            else
            {
                this.floorObj = UnityEngine.Object.Instantiate(baseOddFloorGameObject);  
            }

            this.floorObj.name = "floor_" + (floorIndex + 1);
            this.floorObj.transform.position = new Vector3(0, floorIndex * Floor.FLOOR_HEIGHT, 0);
            this.floorObj.transform.localScale = new Vector3(0.125f, 0.125f, 0.125f);

            // initialize bookshelf objects
            this.books = books;

            int startIndex;
            int endIndex = 0;
            for (int i = 0; i < Constants.TOTAL_BOOKSHELVES_PER_FLOOR; i++)
            {
                startIndex = endIndex;
                if (startIndex + Constants.TOTAL_BOOKS_PER_BOOKSHELF >= books.Count)
                    endIndex = books.Count;
                else
                    endIndex = startIndex + Constants.TOTAL_BOOKS_PER_BOOKSHELF;

                bookshelves.Add(new Bookshelf((Bookshelf.BookshelfType)i,
                                              this.pos_y,
                                              books.GetRange(startIndex,
                                                             endIndex - startIndex)));
            }
        }
    }
}
