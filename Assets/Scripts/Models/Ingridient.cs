using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;


namespace MyBarApp.Models
{
    public class Ingredient
    {
        public string IngredientName { get; set; }
        public float Strength { get; set; }
        public int InStock { get; set; }

        public Ingredient() 
        {
            IngredientName = "UnknownIngridient";
            Strength = 0;
            InStock = 0;
        }
        public Ingredient(string name, float str, int inStock = 0) 
        {
            IngredientName = name;
            Strength = str;
            this.InStock = inStock;
        }      
    }
}
