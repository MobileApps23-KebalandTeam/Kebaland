using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickerPlaceholderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickerPassed()
    {
        LevelsOrders.AddOrders(0);
        LevelChoice.UpdateLevel(true, LevelType.CLICKER);
        IngredientsHolder.AddType(IngredientType.Dough1);
        IngredientsHolder.AddType(IngredientType.Dough3);
        IngredientsHolder.AddType(IngredientType.Meat1);
        IngredientsHolder.AddType(IngredientType.Pepper);
        IngredientsHolder.AddType(IngredientType.Pepper);
        IngredientsHolder.AddType(IngredientType.Tomato);
        IngredientsHolder.AddType(IngredientType.Sauce1);
        IngredientsHolder.AddType(IngredientType.Sauce2);
        /*
         * Comment the line below to mock level passing
         */
        SceneManager.LoadScene("GameLoopScene");
        /*
         * Uncomment the lines below to mock level passing
         */
        // LevelChoice.UpdateLevel(true, LevelType.KEBAB);
        // SceneManager.LoadScene("LevelsChoiceScene");
    }

    public void ClickerFailed()
    {
        LevelChoice.UpdateLevel(false, LevelType.CLICKER);
        SceneManager.LoadScene("LevelsChoiceScene");
    }
}
