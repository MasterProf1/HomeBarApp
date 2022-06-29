using System.IO;
using System.Reflection;
using UnityEngine;


namespace MyBarApp
{
    internal static class Constants
    {
       //public static readonly string cocktailDataFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\Cocktails.txt");
       //public static readonly string ingridientsDataFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\Ingridients.txt");       
       public static readonly string ingridientsDataFilePath = Application.dataPath + "/Resources/Ingridients.txt";
       public static readonly string ingridientsDataFilePathJson = Application.dataPath + "/Resources/Ingridients.json";
       public static readonly string cocktailDataFilePath = Application.dataPath + "/Resources/Cocktails.txt";
    }
}
