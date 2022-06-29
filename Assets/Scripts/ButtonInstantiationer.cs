using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyBarApp.Models;


namespace MyBarApp {
    public class ButtonInstantiationer : MonoBehaviour
    {
        [SerializeField] ScrollRect scrollView;
        [SerializeField] GameObject scrollContent;
        [SerializeField] GameObject buttonPrefab;
        GameObject button;
        List<Ingridient> ingridients;
        List<Cocktail> cocktails;
        InputField InputField;      
        private void Start()
        {           
            ingridients = DataReader.ParseIngridientsFromFile(Constants.ingridientsDataFilePath);            
            cocktails = DataReader.ParseCoctailsFromFile(Constants.cocktailDataFilePath, ingridients);

            foreach (var cocktail in cocktails) 
            {
            cocktail.CalculateCoctailProps();
            }

            scrollView.verticalNormalizedPosition = 1;

        }

        public void CreateCocktailButtonsOnClick() 
        {
            for (int i = 0; i < cocktails.Count; i++)
            {
                CreateCocktailButton(cocktails, i);
            }
        }
        void CreateCocktailButton(List<Cocktail> cocktails, int cocktailID)
        {            
            button = Instantiate(buttonPrefab);
            button.transform.SetParent(scrollContent.transform, false);            
            var texts = button.GetComponentsInChildren<Text>();
            texts[0].text = cocktails[cocktailID].cocktailName;
            texts[1].text = cocktails[cocktailID].totalCapacity.ToString();
            texts[2].text = cocktails[cocktailID].strength.ToString();            
        }

        public void CreateIngredientsButtonsOnClick() 
        {
            for (int i = 0; i < ingridients.Count; i++) 
            {
                CreateIngredientButton(ingridients, i);
            }
        }

        void CreateIngredientButton(List<Ingridient> ingridients, int ingredientID) 
        {           
            button = Instantiate(buttonPrefab);
            button.transform.SetParent(scrollContent.transform, false);
            button.GetComponentInChildren<Text>().text = ingridients[ingredientID].ingredientName;
            InputField = button.GetComponentInChildren<InputField>();
            InputField.GetComponentInChildren<Text>().text = ingridients[ingredientID].inStock.ToString();
        }
       
    }

}

