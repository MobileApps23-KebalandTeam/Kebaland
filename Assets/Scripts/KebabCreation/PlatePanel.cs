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
        IngredientType ingredientType = ingredient.GetIngredientType();
        string plateName = IngredientTypeMethods.getPlateName(ingredientType);
        var newObj = Instantiate(ingredientTypes.GetValueOrDefault(plateName), Vector2.zero, Quaternion.identity, transform);
        float offsetX = UnityEngine.Random.Range(-ingredient.OffsetX(), ingredient.OffsetX());
        float offsetY = UnityEngine.Random.Range(-ingredient.OffsetY(), ingredient.OffsetY());
        Vector3 vect = new Vector3(offsetX, offsetY + actHeight, 0);
        newObj.transform.position = plate.transform.position + vect;

        if (ingredientType is IngredientType.Cucumber or IngredientType.Tomato or IngredientType.Lettuce or IngredientType.Onion)
        {
            newObj.transform.eulerAngles += new Vector3(60, 0, 50);
        }
        
        actHeight += ingredient.AddHeight();
        ingredients.Add(ingredient);
    }

    public List<Ingredient> GetActualPlate()
    {
        return ingredients;
    }

    public void ClearIngredients()
    {
        //call achievement
        if (transform.childCount == 1)
        {
            AchievementManager.Instance.setDelayedEarnAchievement("Ooops");
        }

        actHeight = 0;
        foreach (Transform child in transform)
        {
            if (!child.name.Equals("Plate"))
            {
                Destroy(child.gameObject);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public abstract class Ingredient
    {
        public abstract IngredientType GetIngredientType();
        public abstract int AddHeight();
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
        public override int OffsetX() => Screen.width / 8;
        public override int OffsetY() => Screen.width / 64;
        public override IngredientType GetIngredientType()
        {
            if (type == 0) return IngredientType.Tomato;
            if (type == 1) return IngredientType.Onion;
            if (type == 2) return IngredientType.Cucumber;
            if (type == 3) return IngredientType.Lettuce;
            return IngredientType.Default;
        }

    }


    public class SauceIngredient : Ingredient
    {
        int type;

        public SauceIngredient(int type)
        {
            this.type = type;
        }

        public override int AddHeight() => 0;
        public override int OffsetX() => Screen.width / 16;
        public override int OffsetY() => Screen.width / 64;
        public override IngredientType GetIngredientType() => Enum.Parse<IngredientType>("Sauce" + (type + 1));

    }
}
