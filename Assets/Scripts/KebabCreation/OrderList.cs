using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using static PlatePanel;

public class OrderList : MonoBehaviour
{

    public class SimpleOrder
    {
        // main game object that contains ProgressBar to change
        public GameObject obj;
        public OrderType type;
        public float timeLeft;
        public float maxTime;
        public int reward;

        public SimpleOrder(GameObject obj, OrderType type, float maxTime, int reward)
        {
            this.obj = obj;
            this.type = type;
            this.timeLeft = maxTime;
            this.maxTime = maxTime;
            this.reward = reward;
        }
    }

    private class DelayedOrder
    {
        public SimpleOrder order;
        public float startTime;
        public bool done = false;

        public DelayedOrder(SimpleOrder order, float startTime)
        {
            this.order = order;
            this.startTime = startTime;
        }
    }

    public ToastMessageUtils msg;
    public static int maxAmount = 1;
    public GameObject panelObj;
    public Manager manager;
    public StatisticsScript statistics;

    private static Dictionary<string, GameObject> kebabTypesMap = new Dictionary<string, GameObject>();

    private static List<DelayedOrder> delayedOrders = new List<DelayedOrder>();
    private static List<SimpleOrder> actList = new List<SimpleOrder>();
    private static GameObject[] objects;
    private static Transform[] childs;
    private static GameObject panel;

    void Start()
    {
        panel = panelObj;

        GameObject[] types = Resources.LoadAll<GameObject>("KebabTypes");
        foreach (GameObject obj in types)
        {
            kebabTypesMap.Add(obj.name, obj);
        }
        objects = new GameObject[maxAmount];

        int i = 0;
        childs = new Transform[maxAmount];
        foreach (Transform child in transform)
        {
            if (i >= objects.Length || i >= maxAmount) break;
            childs[i] = child;
            i++;
        }

        RefreshGUI();

    }

    void Update()
    {
        if (manager.IsEndGame()) return;

        foreach (DelayedOrder delayedOrder in delayedOrders)
        {
            if (!delayedOrder.done && delayedOrder.startTime < statistics.getActTime())
            {
                AddKebabRequest(delayedOrder.order);
                delayedOrder.done = true;
            }
        }

        foreach (SimpleOrder ord in actList)
        {
            ord.timeLeft -= Time.deltaTime;
        }

        List<SimpleOrder> toRemove = new List<SimpleOrder>();
        int i = 0;
        foreach (SimpleOrder ord in actList)
        {
            if (i >= maxAmount) break;
            if (ord.timeLeft < 0)
            {
                StatisticsScript.AddPoints(-ord.reward);
                toRemove.Add(ord);
                msg.ShowToast("Nie zd¹¿y³eœ przygotowaæ zamówienia! (-" + ord.reward + ((ord.reward < 5 && ord.reward % 10 != 0) ? " punkty)" : " punktów)"), 2.0f);
                i++;
                continue;
            }
            Slider slider = ord.obj.GetComponentInChildren<Slider>();
            slider.value = ord.timeLeft / ord.maxTime;
            i++;
        }

        foreach (SimpleOrder rem in toRemove)
        {
            RemoveKebabRequest(rem.type);
        }
    }

    public static void AddDelayedKebabRequest(float startTime, OrderType type, float maxSecs)
    {
        SimpleOrder order = new SimpleOrder(kebabTypesMap.GetValueOrDefault(OrderTypeMethods.GetPrefabName(type)), type, maxSecs, OrderTypeMethods.GetReward(type));
        delayedOrders.Add(new DelayedOrder(order, startTime));
    }

    public static void AddKebabRequest(OrderType type, float maxSecs)
    {
        SimpleOrder order = new SimpleOrder(kebabTypesMap.GetValueOrDefault(OrderTypeMethods.GetPrefabName(type)), type, maxSecs, OrderTypeMethods.GetReward(type));
        AddKebabRequest(order);
    }

    public static void AddKebabRequest(SimpleOrder order)
    {
        actList.Add(order);
        actList.Sort((x, y) => x.timeLeft.CompareTo(y.timeLeft));
        RefreshGUI();
    }

    public static void RemoveKebabRequest(OrderType type)
    {
        float minTime = Int32.MaxValue;
        SimpleOrder minOrder = null;
        foreach (SimpleOrder order in actList)
        {

            if (!order.type.Equals(type)) continue;

            float left = order.timeLeft;
            if (minTime >= left)
            {
                minOrder = order;
                minTime = left;
            }
        }
        bool refresh = false;
        if (minOrder != null) {
            int i = 0;
            foreach (SimpleOrder ord in actList)
            {
                if (i >= maxAmount) break;
                if (ord.Equals(minOrder))
                {
                    refresh = true;
                    break;
                }
                i++;
            }
            actList.Remove(minOrder);
            if (refresh) RefreshGUI();
        }
    }

    public static int GivePlate(List<Ingredient> ingredients)
    {

        Dictionary<IngredientType, int> actDict = new Dictionary<IngredientType, int>();
        foreach (Ingredient ing in ingredients)
        {
            int val = actDict.GetValueOrDefault(ing.GetIngredientType(), 0);
            actDict[ing.GetIngredientType()] = val + 1;
        }

        SimpleOrder rightOrd = null;

        foreach (SimpleOrder order in actList)
        {
            bool isOk = true;
            Dictionary<IngredientType, IngredientRange> orderDict = OrderTypeMethods.GetRequiredIngredients(order.type);
            foreach (KeyValuePair<IngredientType, IngredientRange> entry in orderDict)
            {
                int actVal = actDict.GetValueOrDefault(entry.Key, 0);
                if (!entry.Value.IsInRange(actVal))
                {
                    Debug.Log("Not correct for " + order.type + ": " + entry.Key + " (amount: " + actVal + ")");
                    isOk = false;
                    break;
                }
            }
            if (!isOk) continue;

            foreach (KeyValuePair<IngredientType, int> entry in actDict)
            {
                if (!orderDict.ContainsKey(entry.Key))
                {
                    Debug.Log("Not correct for " + order.type + " (2): " + entry.Key);
                    isOk = false;
                    break;
                }
            }

            if (isOk)
            {
                rightOrd = order;
                break;
            }
        }

        ingredients.Clear();

        if (rightOrd != null)
        {
            RemoveKebabRequest(rightOrd.type);
            return rightOrd.reward;
        }

        return 0;
    }

    public static void RefreshGUI()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (!currentScene.name.Equals("GameLoopScene")) return;

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }

        objects = new GameObject[maxAmount];
        foreach (SimpleOrder ord in actList)
        {
            ord.obj = null;
        }

        int i = 0;
        foreach (SimpleOrder ord in actList)
        {
            if (i >= maxAmount) break;

            var newObj = Instantiate(kebabTypesMap.GetValueOrDefault(OrderTypeMethods.GetPrefabName(ord.type)), Vector2.zero, Quaternion.identity, childs[i]);
            newObj.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            newObj.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            objects[i] = newObj;
            ord.obj = newObj;
            i++;
        }

        int add = actList.Count - maxAmount;
        if (add > 0)
        {
            panel.SetActive(true);
            panel.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "+" + add;
        }
        else
        {
            panel.SetActive(false);
        }

    }

    public static void Clear()
    {
        actList.Clear();
        kebabTypesMap.Clear();
    }
}
