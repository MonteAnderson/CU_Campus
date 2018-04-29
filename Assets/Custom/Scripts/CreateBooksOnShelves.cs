using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neo4j.Driver.V1;

namespace CULibrary
{
    public class CreateBooksOnShelves : MonoBehaviour
    {
        public GameObject baseBookGameObject;
        public GameObject basePlayerGameObject;
        public GameObject baseEvenFloorGameObject;
        public GameObject baseOddFloorGameObject;

        private List<Floor> floors = new List<Floor>();
        private List<Book> books = new List<Book>();

        private IDriver _driver;

        // Use this for initialization
        void Start()
        {
            // set base game object references
            Floor.baseEvenFloorGameObject = baseEvenFloorGameObject;
            Floor.baseOddFloorGameObject = baseOddFloorGameObject;
            Book.baseBookGameObject = baseBookGameObject;

            // update player 
            resetPlayerPosition();

            // generate book list
            // TODO: update this to read in from static files or from Neo4j driver
            _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "password"));

            for (int i = 0; i < 4000; i++)
            {
                books.Add(new Book("History", "Apollo 11", "Apollo 11", "https://en.wikipedia.org/wiki/Apollo_11"));
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
            if (books.Count % Constants.TOTAL_BOOKS_PER_FLOOR != 0)
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
