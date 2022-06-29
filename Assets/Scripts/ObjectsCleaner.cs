using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBarApp 
{
    public class ObjectsCleaner : MonoBehaviour
    {
        [SerializeField] GameObject objectHolder;
        List <GameObject> objects = new List<GameObject>();

        public void ClearObjectsOnTheObject()
        {
            // Get list of children objects
            for (int i = 0; i < objectHolder.transform.childCount; i++)
            {
                objects.Add(objectHolder.transform.GetChild(i).gameObject);
            }

            // Annihilate
            foreach (GameObject obj in objects) 
            {
                Destroy(obj);
            }            

        }
        public void DestroyTheObject() 
        {
            Destroy(objectHolder);
        }
    }

}

