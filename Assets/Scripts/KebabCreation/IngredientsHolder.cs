using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientsHolder : MonoBehaviour
{

    // Static amount of types, must be changed after adding/removing extras slots
    private static List<IngredientType> types = new List<IngredientType>();

    public GameObject[] visibleObjects;
    public GameObject[] notVisibleObjects;
    public GameObject dough1O, dough2O, dough3O, meat1O, meat2O, sauce1O, sauce2O, sauce3O;

    private static GameObject[] visible, notVisible;
    private static GameObject dough1, dough2, dough3, meat1, meat2, sauce1, sauce2, sauce3;

    private void Start()
    {
        visible = visibleObjects;
        notVisible = notVisibleObjects;
        dough1 = dough1O;
        dough2 = dough2O;
        dough3 = dough3O;
        meat1 = meat1O;
        meat2 = meat2O;
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

    public static IngredientType GetIngredientType(int ind) => types[ind];

    public static void UpdateTypes()
    {
        int i = 0;
        foreach (IngredientType type in types)
        {
            if (!type.Equals(IngredientType.Tomato) && !type.Equals(IngredientType.Pepper) && !type.Equals(IngredientType.Lettuce) && !type.Equals(IngredientType.Cucumber))
            {
                i++; continue;
            }
            visible[i].GetComponent<RawImage>().texture = Resources.Load<Texture>("Textures/" + IngredientTypeMethods.getBasicName(type));
            notVisible[i].GetComponent<RawImage>().texture = Resources.Load<Texture>("Textures/" + IngredientTypeMethods.getPartName(type));
            i++;
        }

        for (int j = i; j < visible.Length; j++)
        {
            visible[j].SetActive(false);
        }

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

}
