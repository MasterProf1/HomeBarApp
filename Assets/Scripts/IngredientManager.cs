using MyBarApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MyBarApp 
{
    public class IngredientManager : MonoBehaviour
    {       
       // [SerializeField]  GameObject ingredientPanel;
        [SerializeField] GameObject InfoHolder;
        private InformationHolder Info = new InformationHolder();
        List<string> listOfLinesOfIngridientsData;
        List<Ingridient> ingridients;
        //string path = Constants.ingridientsDataFilePath;
        string path;
        int ingredientID;

        private void Awake()
        {
            path = Application.dataPath + "/Resources/Ingridients.txt";
            Info = InfoHolder.GetComponent<InformationHolder>();
            Info.Initialize();
        }
        private void Start()
        {
            ingridients = Info.ingridients;
        }

        public void ChangeIngredientAmountInstock(string newInStock)//, out List<string> listOfLinesOfIngridientsData)
        {
            Ingridient ingridient;
            string ingredientName = gameObject.GetComponentInChildren<Text>().text;
            string[] linesOfIngridientsData = File.ReadAllLines(path);
            listOfLinesOfIngridientsData = linesOfIngridientsData.ToList();
            ingridient = DataReader.GetIngridientByName(ingredientName, ingridients, out ingredientID);
            ingridient.inStock = int.Parse(newInStock);            
            listOfLinesOfIngridientsData[ingredientID] = $"{ingridient.ingredientName} {ingridient.strength} {ingridient.inStock}";            
        }

        public void AcceptInStockChanges() 
        { 
            File.WriteAllLines(path, listOfLinesOfIngridientsData);
        }

    }
}

