using System;
using UnityEngine;

namespace CULibrary
{
    public class Book
    {
        public static GameObject baseBookGameObject;
        private static int totalBookCount = 0;

        public string rootCategory;
        public string parentCategory;
        public string name;
        public string url;
        public GameObject bookObjRef;

        public Book(string rootCategory, string parentCategory, string name, string url)
        {
            this.rootCategory = rootCategory;
            this.parentCategory = parentCategory;
            this.name = name;
            this.url = url;
        }

        public void initialize(Vector3 position, Vector3 rotation)
        {
            Quaternion quaternion = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

            this.bookObjRef = UnityEngine.Object.Instantiate(baseBookGameObject, position, quaternion);
            this.bookObjRef.transform.localScale = new Vector3(2f, 2f, 2f);

            totalBookCount++;
            this.bookObjRef.name = this.rootCategory + "~" + this.name + "~" + this.url;
        }
    }
}