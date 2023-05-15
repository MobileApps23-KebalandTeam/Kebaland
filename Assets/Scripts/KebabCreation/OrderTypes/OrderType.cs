using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderType
{
    Kebab1, Kebab2, Kebab3
}
 
public static class OrderTypeMethods {
    
    public static List<IngredientType> GetRequiredIngredients(OrderType type)
    {
        switch (type)
        {
            case OrderType.Kebab1:
                return new List<IngredientType>();
            default:
                return new List<IngredientType>();
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
