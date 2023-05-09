using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderList : MonoBehaviour
{

    private int maxAmount = 3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] types = Resources.LoadAll<GameObject>("KebabTypes");
        Image obj1 = gameObject.GetComponentInChildren<Image>();
        int i = 0;
        foreach (Transform child in transform)
        {
            if (i >= types.Length || i >= maxAmount) break;
            Image image = child.gameObject.GetComponent<Image>();
            Debug.Log(image);
            var newObj1 = Instantiate(types[i], image.transform.position, Quaternion.identity);
            newObj1.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
