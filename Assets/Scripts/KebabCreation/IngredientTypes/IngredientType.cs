using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType
{
    Tomato, Pepper
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
            default:
                return "";
        }
    }



}
