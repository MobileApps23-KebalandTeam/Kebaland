using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderType
{
    Kebab1, Kebab2, Kebab3
}
 
public class IngredientRange
{
    public int from, to;
    public IngredientRange(int from, int to)
    {
        this.from = from;
        this.to = to;
    }
    public bool IsInRange(int am)
    {
        return am <= to && am >= from;
    }
}

public static class OrderTypeMethods {
    
    public static Dictionary<IngredientType, IngredientRange> GetRequiredIngredients(OrderType type)
    {
        Dictionary<IngredientType, IngredientRange> dict = new Dictionary<IngredientType, IngredientRange>();
        switch (type)
        {
            case OrderType.Kebab1:
                dict.Add(IngredientType.Dough1, new IngredientRange(1, 1));
                dict.Add(IngredientType.Cucumber, new IngredientRange(2, 3));
                dict.Add(IngredientType.Lettuce, new IngredientRange(1, 2));
                dict.Add(IngredientType.Meat1, new IngredientRange(3, 5));
                dict.Add(IngredientType.Sauce1, new IngredientRange(12, 37));
                return dict;
            case OrderType.Kebab2:
                dict.Add(IngredientType.Dough2, new IngredientRange(1, 1));
                dict.Add(IngredientType.Cucumber, new IngredientRange(2, 3));
                dict.Add(IngredientType.Lettuce, new IngredientRange(1, 2));
                dict.Add(IngredientType.Meat2, new IngredientRange(3, 5));
                dict.Add(IngredientType.Sauce2, new IngredientRange(12, 37));
                return dict;
            case OrderType.Kebab3:
                dict.Add(IngredientType.Dough3, new IngredientRange(1, 1));
                dict.Add(IngredientType.Cucumber, new IngredientRange(2, 3));
                dict.Add(IngredientType.Tomato, new IngredientRange(1, 1));
                dict.Add(IngredientType.Pepper, new IngredientRange(3, 4));
                dict.Add(IngredientType.Meat1, new IngredientRange(3, 5));
                dict.Add(IngredientType.Sauce3, new IngredientRange(12, 37));
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
