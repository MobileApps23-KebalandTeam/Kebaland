using System.Collections;
using System.Collections.Generic;
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
        IngredientsHolder.SetType(0, IngredientType.Pepper);
        IngredientsHolder.SetType(1, IngredientType.Tomato);
        /*
         * Comment the line below to mock level passing
         */
        SceneManager.LoadScene("GameLoopScene");
        /*
         * Uncomment the lines below to mock level passing
         */
        // LevelChoice.UpdateLevel(true);
        // SceneManager.LoadScene("LevelsChoiceScene");
    }

    public void ClickerFailed()
    {
        LevelChoice.UpdateLevel(false);
        SceneManager.LoadScene("LevelsChoiceScene");
    }
}
