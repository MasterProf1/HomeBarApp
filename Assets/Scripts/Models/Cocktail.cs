using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBarApp.Models 
{
    public class Cocktail
    {
       public string CocktailName { get; set; }
       public string MakingMethod { get; set; }
       public string Glassware { get; set; }
        // can't be set 
       public int TotalCapacity { get; set; }
        // can't be set 
        public float Strength { get; set; }

       public readonly List<Ingredient> ingridients = new List<Ingredient>();
       public readonly List<int> amountOfIngridient = new List<int>();
       public List<string> IngredientsName = new List<string>();

        public Cocktail()
        {
            CocktailName = "Unnamed Cocktail";
            MakingMethod = "Unknown method";
            Glassware = "Unknown glassware";
        }

        public Cocktail(string name, string method, string glassware)
        {
            CocktailName = name;
            MakingMethod = method;
            this.Glassware = glassware;
        }

        public void AddIngridient(Ingredient ingridientName, int amountOfIngridient) 
        {
            ingridients.Add(ingridientName);
            this.amountOfIngridient.Add(amountOfIngridient);
        }

        public void CalculateCoctailProps() 
        {
            if (ingridients != null) 
            {
                TotalCapacity = amountOfIngridient.Sum();
                float spirit;
                float totalSpirit = 0;
                for (int i = 0; i < ingridients.Count; i++)
                {
                    spirit = (amountOfIngridient[i] * ingridients[i].Strength) / 100;
                    totalSpirit += spirit;
                }
                Strength = (100 * totalSpirit) / TotalCapacity;
            }                       
        }
    }
}



