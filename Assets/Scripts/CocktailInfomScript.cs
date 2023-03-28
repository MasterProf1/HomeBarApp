using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBarApp.Models;
using UnityEngine.UI;

namespace MyBarApp {
    public class CocktailInfomScript : MonoBehaviour
    {
        [SerializeField] GameObject CocktailInfoHolder;

        List<Ingredient> ingridients;
        List<Cocktail> cocktails;
        Cocktail cocktail;
        GameObject cocktailPanel;
        private void Start()
        {
            ingridients = DataReader.ParseIngridientsFromFile(Constants.ingridientsDataFilePath);
            cocktails = DataReader.ParseCoctailsFromFile(Constants.cocktailDataFilePath, ingridients);
            foreach (Cocktail cocktail in cocktails)
                cocktail.CalculateCoctailProps();
        }
        public void SetCocktailInformation() 
        {
            cocktailPanel = Instantiate(CocktailInfoHolder);
            cocktailPanel.transform.SetParent(gameObject.transform.parent.transform.parent.transform.parent.transform.parent.transform, false);            
            string cocktailNameButton = gameObject.GetComponentInChildren<Text>().text;
            cocktail = CocktailSearcher.GetCocktailByName(cocktails, cocktailNameButton);            
            var textsInHolder = cocktailPanel.GetComponentInChildren<Image>().GetComponentsInChildren<Text>();
            textsInHolder[0].text = cocktail.CocktailName;
            string cocktailIngridients = "\nIngridients:\n";
            for (int i = 0; i < cocktail.ingridients.Count; i++) 
            {
                cocktailIngridients += $"{cocktail.ingridients[i].IngredientName} {cocktail.amountOfIngridient[i]}ml\n";
            }
            textsInHolder[1].text = $"Volume: {cocktail.TotalCapacity}\nStrenght: {cocktail.Strength}\nGlassware: {cocktail.Glassware}\n" +
                $"Making method: {cocktail.MakingMethod}\n" + cocktailIngridients;
        }
    }
}

