using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KebabType
{
    public static int idCounter = 0;
    int reward;
    Dictionary<IngredientType, IngredientRange> reqIngredients;
    int id;

    public KebabType()
    {
        id = idCounter;
        idCounter++;
        reward = (int) Random.Range(5.0f, 20.0f);
        reqIngredients = new Dictionary<IngredientType, IngredientRange>();
        List<IngredientType> l = IngredientsHolder.GetIngredientTypes().OrderBy(a => Random.Range(0f, 1f)).ToList();
        int d = 0, m = 0, s = 0, e = 0;
        foreach (IngredientType type in l)
        {
            if (type.Equals(IngredientType.Dough1) || type.Equals(IngredientType.Dough2) || type.Equals(IngredientType.Dough3))
            {
                if (d == 1) continue;
                d++;
                reqIngredients.Add(type, new IngredientRange(1, 1));
            }
            else if (type.Equals(IngredientType.Meat1) || type.Equals(IngredientType.Meat2))
            {
                if (m == 1) continue;
                m++;
                int r = (int) Random.Range(2f, 5f);
                reqIngredients.Add(type, new IngredientRange(r, r + 2));
            }
            else if (type.Equals(IngredientType.Sauce1) || type.Equals(IngredientType.Sauce2) || type.Equals(IngredientType.Sauce3))
            {
                if (s == 1) continue;
                s++;
                reqIngredients.Add(type, new IngredientRange(12, 37));
            }
            else if (type.Equals(IngredientType.Lettuce) || type.Equals(IngredientType.Cucumber) || type.Equals(IngredientType.Tomato) || type.Equals(IngredientType.Onion))
            {
                if (e == 2) continue;
                e++;
                int r = (int)Random.Range(1f, 5f);
                reqIngredients.Add(type, new IngredientRange(r, r + 2));
            }
        }

    }

    public int GetReward()
    {
        return reward;
    }

    public Dictionary<IngredientType, IngredientRange> GetRequiredIngredients()
    {
        return reqIngredients;
    }

    public string GetPrefabName()
    {
        return "ExampleType";
    }

    public int GetId()
    {
        return id;
    }
}

 
public class IngredientRange
{
    public int from, to;
    public IngredientRange(int from, int to)
    {
        this.from = from;
        this.to = to;
    }
    public bool IsInRange(int am)
    {
        return am <= to && am >= from;
    }
}