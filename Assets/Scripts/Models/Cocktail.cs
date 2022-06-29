using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBarApp.Models 
{
    public class Cocktail
    {
       public string cocktailName;
       public string makingMethod;
       public string glassware;
       public int totalCapacity;
       public float strength;       

       public readonly List<Ingridient> ingridients = new List<Ingridient>();
       public readonly List<int> amountOfIngridient = new List<int>();

        public Cocktail()
        {
            cocktailName = "Unnamed Cocktail";
            makingMethod = "Unknown method";
            glassware = "Unknown glassware";
        }

        public Cocktail(string name, string method, string glassware)
        {
            cocktailName = name;
            makingMethod = method;
            this.glassware = glassware;
        }

        public void AddIngridient(Ingridient ingridientName, int amountOfIngridient) 
        {
            ingridients.Add(ingridientName);
            this.amountOfIngridient.Add(amountOfIngridient);
        }

        public void CalculateCoctailProps() 
        {
            if (ingridients != null) 
            {
                totalCapacity = amountOfIngridient.Sum();
                float spirit;
                float totalSpirit = 0;
                for (int i = 0; i < ingridients.Count; i++)
                {
                    spirit = (amountOfIngridient[i] * ingridients[i].strength) / 100;
                    totalSpirit += spirit;
                }
                strength = (100 * totalSpirit) / totalCapacity;
            }                       
        }
    }
}



