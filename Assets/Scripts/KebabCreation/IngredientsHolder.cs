using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientsHolder : MonoBehaviour
{

    // Static amount of types, must be changed after adding/removing extras slots
    private static IngredientType[] types = new IngredientType[] { IngredientType.Pepper, IngredientType.Tomato, IngredientType.Cucumber, IngredientType.Lettuce };

    public GameObject[] visibleObjects;
    public GameObject[] notVisibleObjects;

    private static GameObject[] visible, notVisible;

    private void Start()
    {
        visible = visibleObjects;
        notVisible = notVisibleObjects;
        UpdateTypes();
    }

    // ALL VALUES MUST BE SET HERE TO AVOID SAME INGREDIENT TYPES
    public static void SetType(int ind, IngredientType type)
    {
        types[ind] = type;
    }

    public static IngredientType GetIngredientType(int ind) => types[ind];

    public static void UpdateTypes()
    {
        int i = 0;
        foreach (IngredientType type in types)
        {
            visible[i].GetComponent<RawImage>().texture = Resources.Load<Texture>("Textures/" + IngredientTypeMethods.getBasicName(type));
            notVisible[i].GetComponent<RawImage>().texture = Resources.Load<Texture>("Textures/" + IngredientTypeMethods.getPartName(type));
            i++;
        }
    }

}
