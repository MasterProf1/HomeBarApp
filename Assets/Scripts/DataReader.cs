using MyBarApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyBarApp
{
    internal static class DataReader
    {
        
        public static List<Ingridient> ParseIngridientsFromFile(string path) 
        {
            List<Ingridient> ingridients = new List<Ingridient>();
            string[] listOfIngridients = File.ReadAllLines(path);

            for (int i = 0; i < listOfIngridients.Length; i++)
            {
                string[] separetedListOfIngridients = listOfIngridients[i].Split(' ');
                ingridients.Add(new Ingridient(separetedListOfIngridients[0], float.Parse(separetedListOfIngridients[1]), int.Parse(separetedListOfIngridients[2])));               

            }
            return ingridients;
        }
        // Make this work
        public static  List<Ingridient> ParseIngridientsFromFileJSON(string path) 
        {
            string json = File.ReadAllText(path);

            List<Ingridient> ingridients = JsonUtility.FromJson<List<Ingridient>>(json);
            
            return ingridients;
        }

        public static List<Cocktail> ParseCoctailsFromFile(string path, List<Ingridient> ingridients) 
        {
            List<Cocktail> cocktails = new List<Cocktail>();
            string[] listOfCocktails = File.ReadAllLines(path);
            for (int i = 0; i < listOfCocktails.Length; i++)
            {
                string[] separetedListOfCocktails = listOfCocktails[i].Split(' ');

                cocktails.Add(new Cocktail(separetedListOfCocktails[0], separetedListOfCocktails[1], separetedListOfCocktails[2]));
                for (int j = 3; j < separetedListOfCocktails.Length; j += 2)
                {

                    cocktails[i].AddIngridient(GetIngridientByName(separetedListOfCocktails[j], ingridients), int.Parse(separetedListOfCocktails[j + 1]));
                }
            }
            
            return cocktails;
        }
        internal static Ingridient GetIngridientByName(string name, List<Ingridient> ingridients)
        {
            for (int i = 0; i < ingridients.Count; i++)
            {
                if (name == ingridients[i].ingredientName)
                    return ingridients[i];
            }
            return new Ingridient();
        }

        // Use out parametr modifier for return ingredient ID
        internal static Ingridient GetIngridientByName(string name, List<Ingridient> ingridients, out int ingredientID)
        {
            ingredientID = -1;
            for (int i = 0; i < ingridients.Count; i++)
            {
                if (name == ingridients[i].ingredientName)
                {
                    ingredientID = i;
                    return ingridients[i];
                }
            }
            return new Ingridient();
        }
    }
    
}
