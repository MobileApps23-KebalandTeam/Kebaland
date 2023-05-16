using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePanel : MonoBehaviour
{

    private Dictionary<string, GameObject> ingredientTypes = new Dictionary<string, GameObject>();

    private List<Ingredient> ingredients = new List<Ingredient>();
    private int actHeight = 0;

    public float moveSpeed;
    public GameObject plate;

    private Vector3 target;

    private void Start()
    {
        GameObject[] types = Resources.LoadAll<GameObject>("PlateIngredients");
        foreach (GameObject obj in types)
        {
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
        var newObj = Instantiate(ingredientTypes.GetValueOrDefault(ingredient.Name()), Vector2.zero, Quaternion.identity, transform);
        float offsetX = UnityEngine.Random.Range(-ingredient.OffsetX(), ingredient.OffsetX());
        float offsetY = UnityEngine.Random.Range(-ingredient.OffsetY(), ingredient.OffsetY());
        Vector3 vect = new Vector3(offsetX, offsetY + actHeight, 0);
        newObj.transform.position = plate.transform.position + vect;
        actHeight += ingredient.AddHeight();
        ingredients.Add(ingredient);
    }

    public abstract class Ingredient
    {
        public abstract IngredientType GetIngredientType();
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
        public override IngredientType GetIngredientType() => Enum.Parse<IngredientType>("Dough" + (type + 1));
    }


    public class MeatIngredient : Ingredient
    {
        int type;

        public MeatIngredient(int type)
        {
            this.type = type;
        }

        public override int AddHeight() => 1;
        public override string Name() => "MeatIngredient" + (type + 1);
        public override int OffsetX() => Screen.width / 10;
        public override int OffsetY() => Screen.width / 64;
        public override IngredientType GetIngredientType() => Enum.Parse<IngredientType>("Meat" + (type + 1));

    }


    public class ExtraIngredient : Ingredient
    {
        int type;

        public ExtraIngredient(int type)
        {
            this.type = type;
        }

        public override int AddHeight() => 1;
        public override string Name() => "ExtraIngredient" + (type + 1);
        public override int OffsetX() => Screen.width / 16;
        public override int OffsetY() => Screen.width / 64;
        public override IngredientType GetIngredientType() => IngredientsHolder.GetIngredientType(type);

    }


    public class SauceIngredient : Ingredient
    {
        int type;

        public SauceIngredient(int type)
        {
            this.type = type;
        }

        public override int AddHeight() => 0;
        public override string Name() => "SauceIngredient" + (type + 1);
        public override int OffsetX() => Screen.width / 16;
        public override int OffsetY() => Screen.width / 64;
        public override IngredientType GetIngredientType() => Enum.Parse<IngredientType>("Sauce" + (type + 1));

    }

}
