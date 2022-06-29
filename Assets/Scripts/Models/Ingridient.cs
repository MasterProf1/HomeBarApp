using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;


namespace MyBarApp.Models
{
    public class Ingridient
    {
        public string ingredientName;
        public float strength;
        public int inStock;

        public Ingridient() 
        {
            ingredientName = "UnknownIngridient";
            strength = 0;
            inStock = 0;
        }
        public Ingridient(string name, float str, int inStock = 0) 
        {
            ingredientName = name;
            strength = str;
            this.inStock = inStock;
        }      
    }
}
