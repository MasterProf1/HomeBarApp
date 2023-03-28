using MyBarApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace MyBarApp
{
    internal static class DataReader
    {
        
        public static List<Ingredient> ParseIngridientsFromFile(string path) 
        {
            List<Ingredient> ingridients = new List<Ingredient>();
            string[] listOfIngridients = File.ReadAllLines(path);

            for (int i = 0; i < listOfIngridients.Length; i++)
            {
                string[] separetedListOfIngridients = listOfIngridients[i].Split(' ');
                ingridients.Add(new Ingredient(separetedListOfIngridients[0], float.Parse(separetedListOfIngridients[1]), int.Parse(separetedListOfIngridients[2])));               

            }
            return ingridients;
        }
        
        public static  List<Ingredient> ParseIngridientsFromFileJSON(string path) 
        {
            string json = File.ReadAllText(path);

            List<Ingredient> ingridients = JsonConvert.DeserializeObject<List<Ingredient>>(json);
            
            return ingridients;
        }

        public static List<Cocktail> ParseCoctailsFromFile(string path, List<Ingredient> ingridients) 
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

        // Add ingredients by name from cocktail's class list
        public static List<Cocktail> ParseCoctailsFromFileJson(string path, List<Ingredient> ingridients)
        {
            string json = File.ReadAllText(path);
            List<Cocktail> cocktails = JsonConvert.DeserializeObject<List<Cocktail>>(json);
            for (int i = 0; i < cocktails.Count; i++) 
            {
                string ingredientName;
                cocktails[i].AddIngridient();
            }
            return cocktails;
        }

        internal static Ingredient GetIngridientByName(string name, List<Ingredient> ingridients)
        {
            for (int i = 0; i < ingridients.Count; i++)
            {
                if (name == ingridients[i].IngredientName)
                    return ingridients[i];
            }
            return new Ingredient();
        }

        // Use out parametr modifier for return ingredient ID
        internal static Ingredient GetIngridientByName(string name, List<Ingredient> ingridients, out int ingredientID)
        {
            ingredientID = -1;
            for (int i = 0; i < ingridients.Count; i++)
            {
                if (name == ingridients[i].IngredientName)
                {
                    ingredientID = i;
                    return ingridients[i];
                }
            }
            return new Ingredient();
        }
    }
    
}
