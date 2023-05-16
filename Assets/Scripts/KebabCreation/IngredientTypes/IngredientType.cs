using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType
{
    Default, Dough1, Dough2, Dough3, Meat1, Meat2, Tomato, Pepper, Cucumber, Lettuce, Sauce1, Sauce2, Sauce3
}

public static class IngredientTypeMethods
{

    public static string getBasicName(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Tomato:
                return "tomato";
            case IngredientType.Pepper:
                return "pepper";
            case IngredientType.Cucumber:
                return "cucumber";
            case IngredientType.Lettuce:
                return "lettuce";
            default:
                return "";
        }
    }

    public static string getPartName(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Tomato:
                return "tomatoPart";
            case IngredientType.Pepper:
                return "pepperPart";
            case IngredientType.Cucumber:
                return "cucumberPart";
            case IngredientType.Lettuce:
                return "lettucePart";
            default:
                return "";
        }
    }

    public static string getPlateName(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Tomato:
                return "tomatoPart";
            case IngredientType.Pepper:
                return "pepperPart";
            case IngredientType.Cucumber:
                return "cucumberPart";
            case IngredientType.Lettuce:
                return "lettucePart";
            default:
                return "";
        }
    }



}
