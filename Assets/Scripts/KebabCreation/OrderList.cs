using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class OrderList : MonoBehaviour
{

    public class SimpleOrder
    {
        // main game object that contains ProgressBar to change
        public GameObject obj;
        public string type;
        public float timeLeft;
        public float maxTime;

        public SimpleOrder(GameObject obj, string type, float maxTime)
        {
            this.obj = obj;
            this.type = type;
            this.timeLeft = maxTime;
            this.maxTime = maxTime;
        }

    }

    public int maxAmount = 3;
    public GameObject panel;

    private Dictionary<string, GameObject> kebabTypesMap = new Dictionary<string, GameObject>();

    private List<SimpleOrder> actList = new List<SimpleOrder>();
    private GameObject[] objects;
    private Transform[] childs;

    void Start()
    {
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

        // TODO remove - it's just example
        for (int _ = 0; _ < 15; _++)
            AddKebabRequest("ExampleType", 100.0f);
        AddKebabRequest("ExampleType", 20.0f);
        AddKebabRequest("ExampleType", 5.0f);
        RemoveKebabRequest("ExampleType");

    }

    void Update()
    {
        foreach (SimpleOrder ord in actList)
        {
            ord.timeLeft -= Time.deltaTime;
        }
        
        int i = 0;
        foreach (SimpleOrder ord in actList)
        {
            if (i >= maxAmount) break;
            if (ord.timeLeft < 0)
            {
                // TODO lose game
                //Time.timeScale = 1.0f;
                //SceneManager.LoadScene("MainMenu");
                Debug.LogError("YOU LOST!");
                continue;
            }
            Slider slider = ord.obj.GetComponentInChildren<Slider>();
            slider.value = ord.timeLeft / ord.maxTime;
            i++;
        }
    }

    public void AddKebabRequest(string type, float maxSecs)
    {
        SimpleOrder order = new SimpleOrder(kebabTypesMap.GetValueOrDefault(type), type, maxSecs);
        actList.Add(order);
        actList.Sort((x, y) => x.timeLeft.CompareTo(y.timeLeft));
        int i = 0;
        foreach (SimpleOrder ord in actList)
        {
            if (i >= maxAmount) break;
            if (ord.Equals(order))
            {
                RefreshGUI();
                break;
            }
            i++;
        }
    }

    public void RemoveKebabRequest(string type)
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

    public void RefreshGUI()
    {
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

            var newObj = Instantiate(kebabTypesMap.GetValueOrDefault(ord.type), Vector2.zero, Quaternion.identity, childs[i]);
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
}
