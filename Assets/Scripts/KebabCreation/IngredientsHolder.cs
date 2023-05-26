using UnityEngine;
using UnityEngine.UI;

public class IngredientsHolder : MonoBehaviour
{

    // Static amount of types, must be changed after adding/removing extras slots
    private static readonly IngredientType[] Types = { IngredientType.Onion, IngredientType.Tomato, IngredientType.Cucumber, IngredientType.Lettuce };

    public GameObject[] visibleObjects;
    public GameObject[] notVisibleObjects;

    private static GameObject[] _visible, _notVisible;

    private void Start()
    {
        _visible = visibleObjects;
        _notVisible = notVisibleObjects;
        UpdateTypes();
    }

    // ALL VALUES MUST BE SET HERE TO AVOID SAME INGREDIENT TYPES
    public static void SetType(int ind, IngredientType type)
    {
        Types[ind] = type;
    }

    public static IngredientType GetIngredientType(int ind) => Types[ind];

    public static void UpdateTypes()
    {
        int i = 0;
        foreach (IngredientType type in Types)
        {
            _visible[i].GetComponent<RawImage>().texture = Resources.Load<Texture>("Textures/" + IngredientTypeMethods.getBasicName(type));

            _notVisible[i].GetComponent<RawImage>().texture = Resources.Load<Texture>("Textures/" + IngredientTypeMethods.getPartName(type));
            _notVisible[i].transform.eulerAngles += new Vector3(60, 0, 50);;
            i++;
        }
    }

}
