using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderScript : MonoBehaviour
{
    private Slider slider;
    int i = 1;

    void Start()
    {
        slider = gameObject.GetComponentInChildren<Slider>();
    }

    void Update()
    {
        i++;
        float f = (float) (10000.0 / i);
        setProgress(f);
    }

    public void setProgress(float f)
    {
        slider.value = f;
    }

}
