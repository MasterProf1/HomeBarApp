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
        public static void AddNewCocktail (string nameOfCocktail,string method, string glassware, List<Ingridient> ingridients, List<int> amountOfIngridients)
            {            
            Cocktail cocktailToAppend = new Cocktail();
            if (nameOfCocktail != null) 
            {
            cocktailToAppend.cocktailName = nameOfCocktail;
            }
            if (method != null) 
            {
            cocktailToAppend.makingMethod = method;
            }
            if (glassware != null) 
            {
            cocktailToAppend.glassware = glassware;
            }

            for (int i = 0; i < ingridients.Count; i++) 
            {
                cocktailToAppend.AddIngridient(ingridients[i], amountOfIngridients[i]);
            }
            string textForAppend = "\n" + cocktailToAppend.cocktailName + " " + cocktailToAppend.makingMethod + " " + cocktailToAppend.glassware;
            for (int i = 0; i < cocktailToAppend.ingridients.Count; i++)
            {
                textForAppend += " " + cocktailToAppend.ingridients[i].ingredientName + " " + cocktailToAppend.amountOfIngridient[i];
            }
            
            File.AppendAllText(Constants.cocktailDataFilePath, textForAppend);

        }


        public static void AddNewIngridient(string ingridientName, float strenght = 0, int inStock = 0) 
        {
        Ingridient ingridient = new Ingridient();            
            if (ingridient != null) 
            {
            ingridient.ingredientName = ingridientName;
            }    
            ingridient.strength = strenght;
            ingridient.inStock = inStock;
            string textForAppend = $"\n{ingridient.ingredientName} {ingridient.strength} {ingridient.inStock}";
            
            File.AppendAllText(Constants.ingridientsDataFilePath, textForAppend);
        }
        

    }
}
