using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientsHolder : MonoBehaviour
{

    // Static amount of types, must be changed after adding/removing extras slots
    private readonly Vector3 _rotateVector = new (60, 0, 50);
    private static List<IngredientType> types = new List<IngredientType>();

    public GameObject dough1O, dough2O, dough3O, meat1O, meat2O, tomatoO, cucumberO, pepperO, lettuceO, sauce1O, sauce2O, sauce3O;

    private static GameObject dough1, dough2, dough3, meat1, meat2, tomato, cucumber, pepper, lettuce, sauce1, sauce2, sauce3;

    private void Start()
    {
        dough1 = dough1O;
        dough2 = dough2O;
        dough3 = dough3O;
        meat1 = meat1O;
        meat2 = meat2O;
        tomato = tomatoO;
        cucumber = cucumberO;
        pepper = pepperO;
        lettuce = lettuceO;
        sauce1 = sauce1O;
        sauce2 = sauce2O;
        sauce3 = sauce3O;
        UpdateTypes();
    }

    // ALL VALUES MUST BE SET HERE TO AVOID SAME INGREDIENT TYPES
    public static void AddType(IngredientType type)
    {
        types.Add(type);
    }

    public static List<IngredientType> GetIngredientTypes() => types;

    public static void UpdateTypes()
    {

        if (!types.Contains(IngredientType.Dough1))
        {
            dough1.SetActive(false);
        }
        if (!types.Contains(IngredientType.Dough2))
        {
            dough2.SetActive(false);
        }
        if (!types.Contains(IngredientType.Dough3))
        {
            dough3.SetActive(false);
        }

        if (!types.Contains(IngredientType.Meat1))
        {
            meat1.SetActive(false);
        }
        if (!types.Contains(IngredientType.Meat2))
        {
            meat2.SetActive(false);
        }

        if (!types.Contains(IngredientType.Tomato))
        {
            tomato.SetActive(false);
        }
        if (!types.Contains(IngredientType.Lettuce))
        {
            lettuce.SetActive(false);
        }
        if (!types.Contains(IngredientType.Onion))
        {
            pepper.SetActive(false);
        }
        if (!types.Contains(IngredientType.Cucumber))
        {
            cucumber.SetActive(false);
        }

        if (!types.Contains(IngredientType.Sauce1))
        {
            sauce1.SetActive(false);
        }
        if (!types.Contains(IngredientType.Sauce2))
        {
            sauce2.SetActive(false);
        }
        if (!types.Contains(IngredientType.Sauce3))
        {
            sauce3.SetActive(false);
        }

        // TODO update other objects
    }

    internal static void ClearTypes()
    {
        types.Clear();
    }
}
