using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

//clasa Awaria blokuje i aktywuje podane componenty   
public class Awaria : MonoBehaviour
{
    public ToggleManeger toggleManager; // zmienna obiektu managera Toggles
    public GameObject objectAwaria; // zmienna obiektu awaria
    public ScrollRect scrollRect; // zmienna scrolla
    public bool awariaIF = false; // zmienna czy jest awaria 
    public Button button1; // zmienna przycisku "Lecimy gotować" 

    public void cklick() //metoda kliku przycisku "kontinuje"
    {
        objectAwaria.SetActive(false);//robi nasz obiekt nie aktywnym 
        scrollRect.enabled = true;//robi nasz scrollRect aktywnym 
        awariaIF = false; // zmienna booloa która pozwała sprawdzić czy awaria jest czy nie
        button1.enabled = true;  // robi nasz przycisk aktywnym

        
        for (int i = 0; i < toggleManager.toggleListAll.Count; i++) // przechodzimy po tablice wszystkich toglle i sprawdzamy czy te toggle nie są zaakceptowane
        {
            if (!(toggleManager.toggleListZaakceptowanych.Contains(toggleManager.toggleListAll[i].Item2))) {
                toggleManager.toggleListAll[i].Item1.enabled = true; // i robimy znów actywnymi
            }
           

        }
    }
    public void zablokowac() // metoda bloku componentów
    {
        scrollRect.enabled = false; // blok scrolla
        button1.enabled = false; // blok przycisku
        awariaIF = true; // zapisuje że jest awaria
        objectAwaria.SetActive(true); //robi obiekt awarii aktywnym
 
        for (int i = 0; i < toggleManager.toggleListAll.Count; i++)//robi wszystkie toggle nie aktywnymi
        {
            toggleManager.toggleListAll[i].Item1.enabled = false;

        }
    }

    public void zablokowacAnimacja() // metetoda blokuje componenty przy Animacji
    {
        scrollRect.enabled = false;
        button1.enabled = false;
        awariaIF = true;//wykorzystujemy tótaj też zmienną czy jest awari bo ten stan taki samy jak przy animacji

        for (int i = 0; i < toggleManager.toggleListAll.Count; i++)
        {
            toggleManager.toggleListAll[i].Item1.enabled = false;

        }
    }
    public void odblokowacAnimacja() // metoda odblokowania przy Animacji
    {
       
        scrollRect.enabled = true;
        awariaIF = false; 
        button1.enabled = true;

        for (int i = 0; i < toggleManager.toggleListAll.Count; i++)
        {
            if (!(toggleManager.toggleListZaakceptowanych.Contains(toggleManager.toggleListAll[i].Item2)))
            {
                toggleManager.toggleListAll[i].Item1.enabled = true;
            }


        }
    }
}
