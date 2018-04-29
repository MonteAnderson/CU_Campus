using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBooksOnShelves : MonoBehaviour {

    public const int TOTAL_BOOKS_PER_FLOOR = 780;
    public GameObject book;
    public GameObject player;
    public GameObject floor;
    private List<Floor> floors = new List<Floor>();

    private class Book
    {
        private string name;
        private string url;
        
    }

    private class Bookshelf
    {
        private enum Direction
        {
            NORTH, SOUTH, EAST, WEST
        };

        private double pos_x;
        private double pos_y;
        private Direction direction;

        private Bookshelf(double pos_x, double pos_y, Direction direction)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.direction = direction;
        }
    }

    private class Floor
    {
        public const float FLOOR_HEIGHT = 3.751f;

        private float pos_y;
        private bool isEven;
        private GameObject floorObj;
        private Bookshelf[] bookshelves = new Bookshelf[6];

        public Floor(float pos_y, bool isEven, string floorName)
        {
            this.pos_y = pos_y;
            this.isEven = isEven;
            this.floorObj = GameObject.Find(floorName);

            // TODO: initialize bookshelf objects
        }
    }

    // Use this for initialization
    void Start () { 
        int i = 0;


        //Update player 
        resetPlayerPosition();
        //fillLibrary();
        createFloors(1000);



	}
	
	// Update is called once per frame
    void resetPlayerPosition()
    {
        player.transform.position = new Vector3(0, 1.5f, 0);
    }

    void fillLibrary()
    {
        for (int i = 0; i <= TOTAL_BOOKS_PER_FLOOR; i++)
        {
            //book.name = "this_is_book_" + i;
            //Instantiate(book);
            //book.transform.position = new Vector3(0, 10, 0);
        }
    }

    void createFloors(int books)
    {
        // compute number of floors given results size 
        int numFloors = books / TOTAL_BOOKS_PER_FLOOR;
        if (books % TOTAL_BOOKS_PER_FLOOR != 0)
        {
            numFloors++;
        }

        Debug.Log(numFloors);

        // create floor instances
        bool isEven;
        for(int i=numFloors; i>0; i--)
        {
            if (i % 2 == 0)
            {
                isEven = true;
                Instantiate(floor);
            }
            else
            {
                isEven = false;
                Instantiate(floor);
            }

            floor.name = "floor_" + i;
            floor.transform.position = new Vector3(0, (i - 1) * Floor.FLOOR_HEIGHT, 0);
            floor.transform.localScale = new Vector3(0.125f, 0.125f, 0.125f);

            floors.Add(new Floor(i * Floor.FLOOR_HEIGHT, isEven, floor.name));
        }
    }

}
