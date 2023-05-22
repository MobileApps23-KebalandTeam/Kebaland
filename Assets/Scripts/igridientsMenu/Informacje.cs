using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

public class Informacje : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image backgroud;
    public Text info;
    public Awaria awaria;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("CZESC");
        if (!awaria.awariaIF) {
            backgroud.enabled = true;
            info.enabled = true;
        }
        

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("BYE");
        if (!awaria.awariaIF)
        {
            backgroud.enabled = false;
            info.enabled = false;
        }
        
    }
}

