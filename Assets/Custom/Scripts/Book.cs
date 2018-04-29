using System;
using UnityEngine;

namespace CULibrary
{
    public class Book
    {
        public static GameObject baseBookGameObject;

        private string rootCategory;
        private string parentCategory;
        private string name;
        private string url;
        private GameObject bookObjRef;

        public Book(string rootCategory, string parentCategory, string name, string url)
        {
            this.rootCategory = rootCategory;
            this.parentCategory = parentCategory;
            this.name = name;
            this.url = url;
        }

        public void intialize(float pos_x, float pos_y, float pos_z)
        {
            this.bookObjRef = UnityEngine.Object.Instantiate(baseBookGameObject);
        }
    }
}
