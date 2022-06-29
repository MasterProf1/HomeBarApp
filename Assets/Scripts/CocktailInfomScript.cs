using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBarApp.Models;
using UnityEngine.UI;

namespace MyBarApp {
    public class CocktailInfomScript : MonoBehaviour
    {
        [SerializeField] GameObject CocktailInfoHolder;

        List<Ingridient> ingridients;
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
            textsInHolder[0].text = cocktail.cocktailName;
            string cocktailIngridients = "\nIngridients:\n";
            for (int i = 0; i < cocktail.ingridients.Count; i++) 
            {
                cocktailIngridients += $"{cocktail.ingridients[i].ingredientName} {cocktail.amountOfIngridient[i]}ml\n";
            }
            textsInHolder[1].text = $"Volume: {cocktail.totalCapacity}\nStrenght: {cocktail.strength}\nGlassware: {cocktail.glassware}\n" +
                $"Making method: {cocktail.makingMethod}\n" + cocktailIngridients;
        }
    }
}

