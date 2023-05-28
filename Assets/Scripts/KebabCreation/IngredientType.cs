using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType
{
    Default, Dough1, Dough2, Dough3, Meat1, Meat2, Tomato, Onion, Cucumber, Lettuce, Sauce1, Sauce2, Sauce3
}

public static class IngredientTypeMethods
{

    public static string getBasicName(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Tomato:
                return "tomato";
            case IngredientType.Onion:
                return "onion";
            case IngredientType.Cucumber:
                return "cucumber";
            case IngredientType.Lettuce:
                return "lettuce";
            case IngredientType.Meat1:
                return "meat1";
            case IngredientType.Meat2:
                return "meat2";
            case IngredientType.Dough1:
                return "dough1";
            case IngredientType.Dough2:
                return "dough2";
            case IngredientType.Dough3:
                return "dough3";
            case IngredientType.Sauce1:
                return "sauce1";
            case IngredientType.Sauce2:
                return "sauce2";
            case IngredientType.Sauce3:
                return "sauce3";
            default:
                return "";
        }
    }

    public static string getPartName(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Tomato:
                return "tomato-slice";
            case IngredientType.Onion:
                return "onion-slice";
            case IngredientType.Cucumber:
                return "cucumber-slice";
            case IngredientType.Lettuce:
                return "lettuce-leaf";
            default:
                return "";
        }
    }

    public static string getPlateName(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Onion:
                return "ExtraIngredient1";
            case IngredientType.Tomato:
                return "ExtraIngredient2";
            case IngredientType.Cucumber:
                return "ExtraIngredient3";
            case IngredientType.Lettuce:
                return "ExtraIngredient4";
            case IngredientType.Dough1:
                return "DoughIngredient1";
            case IngredientType.Dough2:
                return "DoughIngredient2";
            case IngredientType.Dough3:
                return "DoughIngredient3";
            case IngredientType.Meat1:
                return "MeatIngredient1";
            case IngredientType.Meat2:
                return "MeatIngredient2";
            case IngredientType.Sauce1:
                return "SauceIngredient1";
            case IngredientType.Sauce2:
                return "SauceIngredient2";
            case IngredientType.Sauce3:
                return "SauceIngredient3";
            default:
                return "";
        }
    }

    public static string getPublicName(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Tomato:
                return "Pomidor";
            case IngredientType.Cucumber:
                return "Ogórek";
            case IngredientType.Lettuce:
                return "Sałata";
            case IngredientType.Onion:
                return "Cebula";
            case IngredientType.Meat1:
                return "Kurczak";
            case IngredientType.Meat2:
                return "Wołowina";
            case IngredientType.Dough1:
                return "Żółte ciasto";
            case IngredientType.Dough2:
                return "Jasne ciasto";
            case IngredientType.Dough3:
                return "Ciemne ciasto";
            case IngredientType.Sauce1:
                return "Musztarda";
            case IngredientType.Sauce2:
                return "Serowy";
            case IngredientType.Sauce3:
                return "Ketchup";
            default:
                return "";
        }
    }



}
