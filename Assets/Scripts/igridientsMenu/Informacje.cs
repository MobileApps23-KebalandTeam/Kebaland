using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

// class EventSystem (przy najechaniem muszką na obrazek )
public class Informacje : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler//te metody z interfeidów
{
    public Image backgroud;//backgraund informacji
    public Text info; //tekst informacji 
    public Awaria awaria; // zmienna awariji

    public void OnPointerEnter(PointerEventData eventData)//metoda przy najechaniu muszą
    {
        if (!awaria.awariaIF) {//jeśli awariji nie ma to przy najechaniu tekst i background aktywne
            backgroud.enabled = true;
            info.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)//przy zjechaniem muszy
    {
        if (!awaria.awariaIF)//jeśli awariji nie ma to przy najechaniu tekst i background nie aktywne
        {
            backgroud.enabled = false;
            info.enabled = false;
        }
    }
}

