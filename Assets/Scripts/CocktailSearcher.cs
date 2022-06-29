using MyBarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBarApp
{
    internal static class CocktailSearcher
    {
        public static List<Cocktail> GetListOfAvailableCocktails (List<Ingridient> availableIngredients, List<Cocktail> cocktails )
            {
            int ingridientCounter = 0;
            // If List of available ingridients is Empty show massege: "You should mark ingridient or buy some"
            List<Cocktail> availableCocktails = new List<Cocktail>();
            foreach (Cocktail cocktail in cocktails) 
            {
                for (int i = 0; i < cocktail.ingridients.Count; i++) 
                {
                    if (availableIngredients.Contains(cocktail.ingridients[i])) 
                    {
                    ingridientCounter++;
                    }                
                }
                if (ingridientCounter == cocktail.ingridients.Count) 
                {
                    availableCocktails.Add(cocktail);
                }
            }            
            // If list of available cocktails is empty?
                return availableCocktails;
        }

        public static Cocktail GetCocktailByName (List<Cocktail> cocktails, string cocktailName) 
        {
            Cocktail cocktail = new Cocktail();
            for (int i = 0; i < cocktails.Count; i++) 
            {
                if (cocktails[i].cocktailName == cocktailName) 
                    cocktail = cocktails[i];
            }
            return cocktail;
        }
    }
}
