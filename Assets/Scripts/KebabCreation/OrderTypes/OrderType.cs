using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderType
{
    Kebab1, Kebab2, Kebab3
}
 
public static class OrderTypeMethods {
    
    public static Dictionary<IngredientType, int> GetRequiredIngredients(OrderType type)
    {
        Dictionary<IngredientType, int> dict = new Dictionary<IngredientType, int>();
        switch (type)
        {
            case OrderType.Kebab1:
                dict.Add(IngredientType.Dough1, 1);
                dict.Add(IngredientType.Cucumber, 2);
                dict.Add(IngredientType.Lettuce, 1);
                dict.Add(IngredientType.Meat1, 1);
                dict.Add(IngredientType.Sauce1, 1);
                return dict;
            case OrderType.Kebab2:
                dict.Add(IngredientType.Dough2, 1);
                dict.Add(IngredientType.Cucumber, 1);
                dict.Add(IngredientType.Lettuce, 1);
                dict.Add(IngredientType.Meat2, 1);
                dict.Add(IngredientType.Sauce2, 1);
                return dict;
            case OrderType.Kebab3:
                dict.Add(IngredientType.Dough3, 1);
                dict.Add(IngredientType.Cucumber, 1);
                dict.Add(IngredientType.Tomato, 1);
                dict.Add(IngredientType.Pepper, 1);
                dict.Add(IngredientType.Meat1, 1);
                dict.Add(IngredientType.Sauce3, 1);
                return dict;
            default:
                return dict;
        }
    }

    public static int GetReward(OrderType type)
    {
        switch (type)
        {
            case OrderType.Kebab1:
                return 10;
            case OrderType.Kebab2:
                return 8;
            case OrderType.Kebab3:
                return 5;
            default:
                return 1;
        }
    }


    public static string GetPrefabName(OrderType type)
    {
        switch (type)
        {
            case OrderType.Kebab1:
                return "ExampleType";
            case OrderType.Kebab2:
                return "ExampleType";
            case OrderType.Kebab3:
                return "ExampleType";
            default:
                return "ExampleType";
        }
    }

}
