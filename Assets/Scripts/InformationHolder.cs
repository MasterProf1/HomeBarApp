using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBarApp.Models;

namespace MyBarApp
{
    public class InformationHolder : MonoBehaviour
    {
        public List<Ingridient> ingridients;
        public List<Cocktail> cocktails;
        public void Initialize()
        {
            // Get whole information about coctails and ingridients from the text files            
             ingridients = DataReader.ParseIngridientsFromFile(Constants.ingridientsDataFilePath);
             cocktails = DataReader.ParseCoctailsFromFile(Constants.cocktailDataFilePath, ingridients);
           // Calculate properties of cocktails
            foreach (var cocktail in cocktails)
            {
                cocktail.CalculateCoctailProps();
            }
        }
    }
}

