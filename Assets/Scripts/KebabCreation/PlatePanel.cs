using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePanel : MonoBehaviour
{

    private Dictionary<string, GameObject> ingredientTypes = new Dictionary<string, GameObject>();

    private List<Ingredient> ingredients = new List<Ingredient>();
    private int actHeight = 0;

    public float moveSpeed;
    private Vector3 target;

    private void Start()
    {
        GameObject[] types = Resources.LoadAll<GameObject>("PlateIngredients");
        foreach (GameObject obj in types)
        {
            Debug.LogError(obj.name);
            ingredientTypes.Add(obj.name, obj);
        }

        target = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime * 100);
    }

    public void Move(Vector3 toDirection)
    {
        target += toDirection;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        Debug.LogError(ingredient.Name());
        var newObj = Instantiate(ingredientTypes.GetValueOrDefault(ingredient.Name()), Vector2.zero, Quaternion.identity, transform);
        Vector2 vect = new Vector2(ingredient.OffsetX(), ingredient.OffsetY() + actHeight);
        newObj.GetComponent<RectTransform>().offsetMin = vect;
        newObj.GetComponent<RectTransform>().offsetMax = vect;
        actHeight += ingredient.AddHeight();
        ingredients.Add(ingredient);
    }

    public abstract class Ingredient
    {
        public abstract int AddHeight();
        public abstract string Name();
        public abstract int OffsetX();
        public abstract int OffsetY();
    }

    public class DoughIngredient : Ingredient
    {
        int type;

        public DoughIngredient(int type)
        {
            this.type = type;
        }

        public override int AddHeight() => 5;
        public override string Name() => "DoughIngredient" + (type + 1);
        public override int OffsetX() => 0;
        public override int OffsetY() => 0;

    }

}
