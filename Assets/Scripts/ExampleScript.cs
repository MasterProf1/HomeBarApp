using MyBarApp.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBarApp 
{
    public class ExampleScript : MonoBehaviour
    {
        List<Ingridient> testIngridients = new List<Ingridient>();
        // Start is called before the first frame update
        void Start()
        {            
            testIngridients = DataReader.ParseIngridientsFromFileJSON(Constants.ingridientsDataFilePathJson);
            print(testIngridients.Count);
        }

        public void PrintIngredients() 
        {

            for (int i = 0; i < testIngridients.Count; i++) 
            {
                print($"Name: {testIngridients[i].ingredientName} Strength: {testIngridients[i].strength}");
            }
        }

    }

}
