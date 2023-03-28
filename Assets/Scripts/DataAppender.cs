using MyBarApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBarApp
{
    internal static class DataAppender
    {
        public static void AddNewCocktail (string nameOfCocktail,string method, string glassware, List<Ingredient> ingridients, List<int> amountOfIngridients)
            {            
            Cocktail cocktailToAppend = new Cocktail();
            if (nameOfCocktail != null) 
            {
            cocktailToAppend.CocktailName = nameOfCocktail;
            }
            if (method != null) 
            {
            cocktailToAppend.MakingMethod = method;
            }
            if (glassware != null) 
            {
            cocktailToAppend.Glassware = glassware;
            }

            for (int i = 0; i < ingridients.Count; i++) 
            {
                cocktailToAppend.AddIngridient(ingridients[i], amountOfIngridients[i]);
            }
            string textForAppend = "\n" + cocktailToAppend.CocktailName + " " + cocktailToAppend.MakingMethod + " " + cocktailToAppend.Glassware;
            for (int i = 0; i < cocktailToAppend.ingridients.Count; i++)
            {
                textForAppend += " " + cocktailToAppend.ingridients[i].IngredientName + " " + cocktailToAppend.amountOfIngridient[i];
            }
            
            File.AppendAllText(Constants.cocktailDataFilePath, textForAppend);

        }


        public static void AddNewIngridient(string ingridientName, float strenght = 0, int inStock = 0) 
        {
        Ingredient ingridient = new Ingredient();            
            if (ingridient != null) 
            {
            ingridient.IngredientName = ingridientName;
            }    
            ingridient.Strength = strenght;
            ingridient.InStock = inStock;
            string textForAppend = $"\n{ingridient.IngredientName} {ingridient.Strength} {ingridient.InStock}";
            
            File.AppendAllText(Constants.ingridientsDataFilePath, textForAppend);
        }
        

    }
}
